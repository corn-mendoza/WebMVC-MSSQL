using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace WebMVCMSSQL.Migrations
{
    [DbContext(typeof(ReleaseContext))]
    partial class ReleaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebMVC_MSSQL.Models.Release", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ApplicationName")
                        .IsConcurrencyToken()
                        .IsRequired();

                    b.Property<string>("Build");

                    b.Property<string>("DownloadLink");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<decimal>("StorePrice");

                    b.Property<string>("VersionText");

                    b.HasKey("Id");

                    b.ToTable("Release");
                });

            modelBuilder.Entity("WebMVC_MSSQL.Models.ReleaseNote", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Data")
                        .IsRequired();

                    b.Property<int?>("ReleaseId");

                    b.HasKey("Id");

                    b.HasIndex("ReleaseId");

                    b.ToTable("ReleaseNotes");
                });

            modelBuilder.Entity("WebMVC_MSSQL.Models.ReleaseNote", b =>
                {
                    b.HasOne("WebMVC_MSSQL.Models.Release", "Release")
                        .WithMany("ReleaseNotes")
                        .HasForeignKey("ReleaseId");
                });
        }
    }
}
