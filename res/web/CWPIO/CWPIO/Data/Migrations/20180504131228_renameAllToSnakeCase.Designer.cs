﻿// <auto-generated />
using CWPIO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CWPIO.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180504131228_renameAllToSnakeCase")]
    partial class renameAllToSnakeCase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("CWPIO.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasName("email_index");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("user_name_index");

                    b.ToTable("users","identity");
                });

            modelBuilder.Entity("CWPIO.Data.BountyCampaing", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("FaClass")
                        .HasColumnName("fa_class")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("pk_bounty_campaing");

                    b.ToTable("bounty_campaing");
                });

            modelBuilder.Entity("CWPIO.Data.BountyCampaingItemType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("BountyCampaingId")
                        .IsRequired()
                        .HasColumnName("bounty_campaing_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(200);

                    b.Property<bool>("NeedToApprove")
                        .HasColumnName("need_to_approve");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("price")
                        .HasDefaultValue(0m);

                    b.Property<int>("TypeId")
                        .HasColumnName("type_id");

                    b.HasKey("Id")
                        .HasName("pk_bounty_campaing_item_type");

                    b.HasAlternateKey("TypeId", "BountyCampaingId")
                        .HasName("ak_bounty_campaing_item_type_type_id_bounty_campaing_id");

                    b.HasIndex("BountyCampaingId")
                        .HasName("ix_bounty_campaing_item_type_bounty_campaing_id");

                    b.ToTable("bounty_campaing_item_type");
                });

            modelBuilder.Entity("CWPIO.Data.DataProtectionKey", b =>
                {
                    b.Property<string>("FriendlyName")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("friendly_name")
                        .HasColumnType("text");

                    b.Property<string>("XmlData")
                        .HasColumnName("xml_data")
                        .HasColumnType("text");

                    b.HasKey("FriendlyName")
                        .HasName("pk_data_protection_keys");

                    b.ToTable("data_protection_keys","core");
                });

            modelBuilder.Entity("CWPIO.Data.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("culture")
                        .HasDefaultValue("");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<bool>("EmailSend")
                        .HasColumnName("email_send");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<bool>("Unsubscribe")
                        .HasColumnName("unsubscribe");

                    b.HasKey("Id")
                        .HasName("pk_subscribers");

                    b.ToTable("subscribers");
                });

            modelBuilder.Entity("CWPIO.Data.UserBountyCampaing", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("BountyCampaingId")
                        .HasColumnName("bounty_campaing_id");

                    b.Property<decimal>("TotalCoinEarned")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("total_coin_earned")
                        .HasDefaultValue(0m);

                    b.Property<int>("TotalItemCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("total_item_count")
                        .HasDefaultValue(0);

                    b.HasKey("UserId", "BountyCampaingId")
                        .HasName("pk_user_bounty_campaing");

                    b.HasIndex("BountyCampaingId")
                        .HasName("ix_user_bounty_campaing_bounty_campaing_id");

                    b.ToTable("user_bounty_campaing");
                });

            modelBuilder.Entity("CWPIO.Data.UserBountyCampaingItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("BountyCampaingId")
                        .IsRequired()
                        .HasColumnName("bounty_campaing_id");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnName("is_accepted");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("is_deleted");

                    b.Property<int>("ItemType")
                        .HasColumnName("item_type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnName("url")
                        .HasMaxLength(255);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_bounty_campaing_item");

                    b.HasIndex("ItemType", "BountyCampaingId")
                        .HasName("ix_user_bounty_campaing_item_item_type_bounty_campaing_id");

                    b.HasIndex("UserId", "BountyCampaingId")
                        .HasName("ix_user_bounty_campaing_item_user_id_bounty_campaing_id");

                    b.ToTable("user_bounty_campaing_item");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("role_name_index");

                    b.ToTable("roles","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasName("ix_role_claims_role_id");

                    b.ToTable("role_claims","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasName("ix_user_claims_user_id");

                    b.ToTable("user_claims","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasName("ix_user_logins_user_id");

                    b.ToTable("user_logins","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ix_user_roles_role_id");

                    b.ToTable("user_roles","identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("user_tokens","identity");
                });

            modelBuilder.Entity("CWPIO.Data.BountyCampaingItemType", b =>
                {
                    b.HasOne("CWPIO.Data.BountyCampaing", "BountyCampaing")
                        .WithMany("ItemTypes")
                        .HasForeignKey("BountyCampaingId")
                        .HasConstraintName("fk_bounty_campaing_item_type_bounty_campaing_bounty_campaing_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CWPIO.Data.UserBountyCampaing", b =>
                {
                    b.HasOne("CWPIO.Data.BountyCampaing", "BountyCampaing")
                        .WithMany("UserBounties")
                        .HasForeignKey("BountyCampaingId")
                        .HasConstraintName("fk_user_bounty_campaing_bounty_campaing_bounty_campaing_id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CWPIO.Data.ApplicationUser", "User")
                        .WithMany("UserBounties")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_bounty_campaing_users_user_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CWPIO.Data.UserBountyCampaingItem", b =>
                {
                    b.HasOne("CWPIO.Data.BountyCampaingItemType")
                        .WithMany()
                        .HasForeignKey("ItemType", "BountyCampaingId")
                        .HasConstraintName("fk_user_bounty_campaing_item_bounty_campaing_item_type_item_type_bounty_campaing_id")
                        .HasPrincipalKey("TypeId", "BountyCampaingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CWPIO.Data.UserBountyCampaing", "UserBounty")
                        .WithMany("Items")
                        .HasForeignKey("UserId", "BountyCampaingId")
                        .HasConstraintName("fk_user_bounty_campaing_item_user_bounty_campaing_user_id_bounty_campaing_id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CWPIO.Data.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CWPIO.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_logins_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CWPIO.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CWPIO.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_tokens_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
