﻿using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using pre_ico_web_site.Models;
using System.Globalization;
using System.Threading.Tasks;

namespace pre_ico_web_site.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IStringLocalizer<EmailSender> _localizer;
        private MailjetClient _client;
        private IOptions<MailSettings> _mailSettings;
        private ILogger _logger;
        public EmailSender(IOptions<MailSettings> mailSettings, IStringLocalizer<EmailSender> localizer, ILogger<EmailSender> logger)
        {
            _client = new MailjetClient(mailSettings.Value.ApiKey, mailSettings.Value.ApiSecret) { Version = ApiVersion.V3 };
            _localizer = localizer;
            _mailSettings = mailSettings;
            _logger = logger;
        }


        //public async Task<bool> SendEmailAsync(string email, string subject, string message, string html = null)
        //{

        //    MailjetRequest request = new MailjetRequest { Resource = Send.Resource }
        //        .Property(Send.FromEmail, "info@cryptoworkplace.io")
        //        .Property(Send.FromName, "CryptoWorkPlace Info")
        //        .Property(Send.Subject, subject)
        //        .Property(Send.TextPart, message);
        //    if (!string.IsNullOrEmpty(html))
        //    {
        //        request.Property(Send.HtmlPart, html);
        //    }

        //    request.Property(Send.Recipients, new JArray { new JObject { { "Email", email } } });


        //    return await SendRequestAsync(request);
        //}

        public async Task<bool> SendEmailSubscription(string email, string name)
        {
            var res = await AddUserToContactList(email, name);
            if (res)
            {
                var welcomeTemplateId = _mailSettings.Value.WelcomeTemplateId.ContainsKey(CultureInfo.CurrentUICulture.Name) ?
                        _mailSettings.Value.WelcomeTemplateId[CultureInfo.CurrentUICulture.Name] :
                        _mailSettings.Value.WelcomeTemplateId["en-US"];

                MailjetRequest request = new MailjetRequest { Resource = Send.Resource }
                    .Property(Send.FromEmail, "info@cryptoworkplace.io")
                    .Property(Send.FromName, "CryptoWorkPlace Info")
                    .Property(Send.Subject, _localizer["Subscribe_Subject"].Value)
                    .Property(Send.MjTemplateID, welcomeTemplateId.ToString())
                    .Property(Send.MjTemplateLanguage, true)
                    .Property(Send.Recipients, new JArray { new JObject { { "Email", email } } });

                return await SendRequestAsync(request);
            }
            return false;
        }

        public async Task<bool> SendEmailValidationAsync(string email, string validateLink)
        {
            var mailTemplateId = _mailSettings.Value.MailValidationTemplateId.ContainsKey(CultureInfo.CurrentUICulture.Name) ?
                    _mailSettings.Value.MailValidationTemplateId[CultureInfo.CurrentUICulture.Name] :
                    _mailSettings.Value.MailValidationTemplateId["en-US"];

            MailjetRequest request = new MailjetRequest { Resource = Send.Resource }
                .Property(Send.FromEmail, "support@cryptoworkplace.io")
                .Property(Send.FromName, "CryptoWorkPlace Support")
                .Property(Send.Subject, "Customer account verification")
                .Property(Send.MjTemplateID, mailTemplateId.ToString())
                .Property(Send.MjTemplateLanguage, true)
                .Property(Send.Vars, new JObject {
                    { "link", validateLink }
                })
                .Property(Send.Recipients, new JArray { new JObject { { "Email", email } } });

            return await SendRequestAsync(request);
        }

        public async Task<bool> SendEmailResetPasswordAsync(string email, string resetPasswordLink)
        {
            var mailTemplateId = _mailSettings.Value.MailResetPasswordTemplateId.ContainsKey(CultureInfo.CurrentUICulture.Name) ?
                    _mailSettings.Value.MailResetPasswordTemplateId[CultureInfo.CurrentUICulture.Name] :
                    _mailSettings.Value.MailResetPasswordTemplateId["en-US"];

            MailjetRequest request = new MailjetRequest { Resource = Send.Resource }
                .Property(Send.FromEmail, "support@cryptoworkplace.io")
                .Property(Send.FromName, "CryptoWorkPlace Support")
                .Property(Send.Subject, "Reset password request")
                .Property(Send.MjTemplateID, mailTemplateId.ToString())
                .Property(Send.MjTemplateLanguage, true)
                .Property(Send.Vars, new JObject {
                    { "link", resetPasswordLink }
                })
                .Property(Send.Recipients, new JArray { new JObject { { "Email", email } } });
            return await SendRequestAsync(request);
        }
        
        public async Task<bool> SendEmailFailedTransactionAsync(string email, string htmlText)
        {
            var mailTemplateId = _mailSettings.Value.MailTemplateId.ContainsKey(CultureInfo.CurrentUICulture.Name) ?
                    _mailSettings.Value.MailTemplateId[CultureInfo.CurrentUICulture.Name] :
                    _mailSettings.Value.MailTemplateId["en-US"];

            MailjetRequest request = new MailjetRequest { Resource = Send.Resource }
                .Property(Send.FromEmail, "info@cryptoworkplace.io")
                .Property(Send.FromName, "CryptoWorkPlace Info")
                .Property(Send.Subject, _localizer["Subscribe_Subject"].Value)
                .Property(Send.MjTemplateID, mailTemplateId.ToString())
                .Property(Send.MjTemplateLanguage, true)
                .Property(Send.Vars, new JObject {
                    { "message", htmlText }
                })
                .Property(Send.Recipients, new JArray { new JObject { { "Email", email } } });

            return await SendRequestAsync(request);
        }

        private async Task<bool> AddUserToContactList(string email, string name)
        {
            var request = new MailjetRequest { Resource = Contact.Resource, ResourceId = ResourceId.Alphanumeric(email) };
            var response = await _client.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                request = new MailjetRequest { Resource = Contact.Resource }
                    .Property(Contact.Name, name)
                    .Property(Contact.Email, email);
                response = await _client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    request = new MailjetRequest { Resource = Contact.Resource, ResourceId = ResourceId.Alphanumeric(email) };
                    response = await _client.GetAsync(request);
                }
            }

            if (response.IsSuccessStatusCode)
            {
                var contactId = response.GetData().First.Value<long>(Contact.ID);

                request = new MailjetRequest { Resource = Contactdata.Resource, ResourceId = ResourceId.Numeric(contactId) }
                    .Property(Contactdata.Data, new JArray {
                        new JObject { {"Name", "country" }, { "Value", CultureInfo.CurrentUICulture.Name } }
                    });
                response = await _client.PutAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var contactListId = _mailSettings.Value.ContacListId.ContainsKey(CultureInfo.CurrentUICulture.Name) ?
                        _mailSettings.Value.ContacListId[CultureInfo.CurrentUICulture.Name] :
                        _mailSettings.Value.ContacListId["en-US"];
                    request = new MailjetRequest { Resource = ContactManagecontactslists.Resource, ResourceId = ResourceId.Numeric(contactId) }
                        .Property(ContactManagecontactslists.ContactsLists, new JArray {
                            new JObject {
                                { "ListId", contactListId.ToString() },
                                { "Action", "addnoforce" }
                            }
                        });
                    response = await _client.PostAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        _logger.LogError(response.GetErrorMessage());
                    }
                }
                else
                {
                    _logger.LogError(response.GetErrorMessage());
                }
            }
            else
            {
                _logger.LogError(response.GetErrorMessage());
            }

            return false;
        }

        private async Task<bool> SendRequestAsync(MailjetRequest request)
        {
            MailjetResponse response = await _client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                _logger.LogError(response.GetErrorMessage());
            }

            return false;
        }

    }
}
