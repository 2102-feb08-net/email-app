﻿// <auto-generated />
using System;
using EmailApp.DataAccess.EfModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmailApp.DataAccess.Migrations
{
    [DbContext(typeof(EmailContext))]
    partial class EmailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EmailApp.DataAccess.EfModel.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "nick.escalona@revature.com"
                        },
                        new
                        {
                            Id = 2,
                            Address = "nicholasescalona@outlook.com"
                        });
                });

            modelBuilder.Entity("EmailApp.DataAccess.EfModel.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<int>("FromId")
                        .HasColumnType("integer");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset>("OrigDate")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<int?>("ToId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("Guid")
                        .IsUnique();

                    b.HasIndex("ToId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "this is a message to say hello",
                            FromId = 1,
                            Guid = new Guid("57d462ca-a9ce-4417-b8a4-d9b59907c7a6"),
                            IsDeleted = false,
                            OrigDate = new DateTimeOffset(new DateTime(2021, 3, 20, 22, 37, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)),
                            Subject = "hello",
                            ToId = 2
                        },
                        new
                        {
                            Id = 2,
                            Body = "this is a reply to hello",
                            FromId = 2,
                            Guid = new Guid("bd682c41-68db-4c00-9dd2-814b8013e563"),
                            IsDeleted = false,
                            OrigDate = new DateTimeOffset(new DateTime(2021, 3, 20, 22, 40, 1, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)),
                            Subject = "Re: hello",
                            ToId = 1
                        });
                });

            modelBuilder.Entity("EmailApp.DataAccess.EfModel.Message", b =>
                {
                    b.HasOne("EmailApp.DataAccess.EfModel.Account", "From")
                        .WithMany("SentMessages")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmailApp.DataAccess.EfModel.Account", "To")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ToId");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("EmailApp.DataAccess.EfModel.Account", b =>
                {
                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
