﻿using System;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.SampleApp.Roles;

namespace Abp.Zero.SampleApp.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            UserStore userStore, 
            RoleManager roleManager, 
            IPermissionManager permissionManager, 
            IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, 
            IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, 
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            ISettingManager settingManager,
            IdentityEmailMessageService emailService) 
            : base(
                  userStore, 
                  roleManager, 
                  permissionManager, 
                  unitOfWorkManager, 
                  cacheManager, 
                  organizationUnitRepository, 
                  userOrganizationUnitRepository, 
                  organizationUnitSettings,
                  localizationManager,
                  emailService,
                  settingManager)
        {
            DefaultAccountLockoutTimeSpan = TimeSpan.FromSeconds(0.5);
        }
    }
}