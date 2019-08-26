using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Data
{
    public static class ModelBuilderSeed
    {
        public static void Seed(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (!context.Users.Any())
                {
                    var hasher = new PasswordHasher<IdentityUser>();
                    context.Users.Add(new IdentityUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "Admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@admin.com",
                        NormalizedEmail = "ADMIN@ADMIN.COM",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "admin"),
                        SecurityStamp = string.Empty
                    });
                };

                context.SaveChanges();
            }            
        }
    }
}
