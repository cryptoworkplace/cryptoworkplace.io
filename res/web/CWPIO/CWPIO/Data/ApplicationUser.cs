﻿using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWPIO.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Claims = new HashSet<IdentityUserClaim<string>>();
            UserBounties = new HashSet<UserBountyCampaing>();
        }

        public bool IsDeleted { get; set; }

        [JsonIgnore] public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        [JsonIgnore] public virtual ICollection<UserBountyCampaing> UserBounties { get; set; }
        
    }
}
