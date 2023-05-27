﻿using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Abp.MultiTenancy
{
    /// <summary>
    /// Represents a Tenant of the application.
    /// </summary>
    public class AbpTenant : Entity, IHasCreationTime
    {
        /// <summary>
        /// Tenancy name. This property is the UNIQUE name of this Tenant.
        /// It can be used as subdomain name.
        /// </summary>
        public virtual string TenancyName { get; set; }

        /// <summary>
        /// Display name of the Tenant.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Creation time of this Tenant.
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// Creates a new <see cref="AbpTenant"/> object.
        /// </summary>
        public AbpTenant()
        {
            CreationTime = DateTime.Now; //TODO: UtcNow?
        }

        /// <summary>
        /// Creates a new <see cref="AbpTenant"/> object.
        /// </summary>
        /// <param name="tenancyName">UNIQUE name of this Tenant</param>
        /// <param name="name">Display name of the Tenant</param>
        public AbpTenant(string tenancyName, string name)
            : this()
        {
            TenancyName = tenancyName;
            Name = name;
        }
    }
}
