﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senparc.Xncf.Tanent.Domain.DatabaseModel;

#nullable disable

namespace Senparc.Xncf.Tenant.Domain.Migrations.Sqlite
{
    [DbContext(typeof(TenantSenparcEntities_Sqlite))]
    [Migration("20211211105002_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.TenantInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRemark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Flag")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Remark")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TenantInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
