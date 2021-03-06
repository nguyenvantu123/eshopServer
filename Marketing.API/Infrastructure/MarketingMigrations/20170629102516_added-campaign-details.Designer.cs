﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Marketing.API.Infrastructure;

namespace Marketing.API.Infrastructure.MarketingMigrations
{
    [DbContext(typeof(MarketingContext))]
    [Migration("20170629102516_added-campaign-details")]
    partial class addedcampaigndetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:Sequence:.campaign_hilo", "'campaign_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:Sequence:.rule_hilo", "'rule_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marketing.API.Model.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "campaign_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<string>("DetailsUri");

                    b.Property<DateTime>("From")
                        .HasColumnName("From");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<string>("PictureName");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasColumnName("PictureUri");

                    b.Property<DateTime>("To")
                        .HasColumnName("To");

                    b.HasKey("Id");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("Marketing.API.Model.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "rule_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("CampaignId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<int>("RuleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Rule");

                    b.HasDiscriminator<int>("RuleTypeId");
                });

            modelBuilder.Entity("Marketing.API.Model.PurchaseHistoryRule", b =>
                {
                    b.HasBaseType("Marketing.API.Model.Rule");


                    b.ToTable("PurchaseHistoryRule");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Marketing.API.Model.UserLocationRule", b =>
                {
                    b.HasBaseType("Marketing.API.Model.Rule");

                    b.Property<int>("LocationId")
                        .HasColumnName("LocationId");

                    b.ToTable("UserLocationRule");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Marketing.API.Model.UserProfileRule", b =>
                {
                    b.HasBaseType("Marketing.API.Model.Rule");


                    b.ToTable("UserProfileRule");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Marketing.API.Model.Rule", b =>
                {
                    b.HasOne("Marketing.API.Model.Campaign", "Campaign")
                        .WithMany("Rules")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
