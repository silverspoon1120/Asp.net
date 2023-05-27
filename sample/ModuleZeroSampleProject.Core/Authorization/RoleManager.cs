﻿using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using ModuleZeroSampleProject.MultiTenancy;
using ModuleZeroSampleProject.Users;

namespace ModuleZeroSampleProject.Authorization
{
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(
            RoleStore store, 
            IPermissionManager permissionManager, 
            IRoleManagementConfig roleManagementConfig, 
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                unitOfWorkManager)
        {
        }
    }
}