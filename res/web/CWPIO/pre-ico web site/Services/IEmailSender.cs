﻿using System.Threading.Tasks;

namespace pre_ico_web_site.Services
{
    public interface IEmailSender
    {
        //Task<bool> SendEmailAsync(string email, string subject, string message, string html = null);
        Task<bool> SendEmailSubscription(string email, string name);
        Task<bool> SendEmailFailedTransactionAsync(string email, string htmlText);
        Task<bool> SendEmailValidationAsync(string email, string validateLink);
        Task<bool> SendEmailResetPasswordAsync(string email, string resetPasswordLink);
    }
}
