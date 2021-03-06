﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pre_ico_web_site.Data;

namespace pre_ico_web_site.Migrations
{
    [DbContext(typeof(DataProtectionDbContext))]
    partial class DataProtectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("pre_ico_web_site.Data.DataProtectionKey", b =>
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
#pragma warning restore 612, 618
        }
    }
}
