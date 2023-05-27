﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Application.Authorization.Permissions;
using Abp.Domain.Entities.Auditing;
using Abp.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace Abp.Application.Authorization.Roles
{
    /// <summary>
    /// Represents a role in an application.
    /// </summary>
    public class AbpRole : AuditedEntity, IRole<int>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Unique name of this role.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// List of permissions of this role.
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual IList<Permission> Permissions { get; set; }
    }
}
