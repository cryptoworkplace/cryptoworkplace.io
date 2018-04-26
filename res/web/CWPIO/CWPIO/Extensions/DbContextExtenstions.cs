﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CWPIO.Data
{
    public static class DbContextExtenstions
    {
        public static async Task<ApplicationUser> GetCurrentUserAsync(this ApplicationDbContext dbContext, ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
                return null;
            var dbUser = await dbContext.Users.FindAsync(claim.Value);
            return dbUser;
        }
    }
}
