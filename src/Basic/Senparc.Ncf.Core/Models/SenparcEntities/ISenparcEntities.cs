﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Senparc.Ncf.Core.Models
{
    /// <summary>
    /// ISenparcEntities
    /// </summary>
    public interface ISenparcEntities : IDisposable, IInfrastructure<IServiceProvider>, IDbContextDependencies, IDbSetCache, /*IDbQueryCache, */IDbContextPoolable
    {
        void SetGlobalQuery<T>(ModelBuilder builder) where T : EntityBase;

        /// <summary>
        /// 重置合并状态
        /// </summary>
        void ResetMigrate();

        /// <summary>
        /// 执行 EF Core 的合并操作（等价于 update-database）
        /// <para>出于安全考虑，每次执行 Migrate() 方法之前，必须先执行 ResetMigrate() 开启允许 Migrate 执行的状态。</para>
        /// </summary>
        void Migrate();
    }
}
