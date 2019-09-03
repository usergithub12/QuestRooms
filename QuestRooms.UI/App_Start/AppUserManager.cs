﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using QuestRooms.DAL;
using QuestRooms.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestRooms.UI.App_Start
{
  
        public class AppUserManager : UserManager<AppUser>
        {
            public AppUserManager(IUserStore<AppUser> store)
               : base(store)
            {
            }

            public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
            {
                var manager =
                    new AppUserManager(
                        new UserStore<AppUser>(
                            context.Get<RoomsContext>()
                            ));


                // Настройка логики проверки имен пользователей
                manager.UserValidator = new UserValidator<AppUser>(manager)
                {
                    //в имени юзер могут быть буквы символы и цифры
                    AllowOnlyAlphanumericUserNames = false,
                    //емейл должен быть уникальным
                    RequireUniqueEmail = true
                };

                // Настройка логики проверки паролей
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                // Настройка параметров блокировки по умолчанию
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                //Настройка токена
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<AppUser>(dataProtectionProvider.Create("SuperToken"));
                }

                return manager;
            }

        }
    }
