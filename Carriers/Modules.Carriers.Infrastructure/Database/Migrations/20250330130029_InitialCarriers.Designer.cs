﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.Carriers.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.Carriers.Infrastructure.Database.Migrations
{
    [DbContext(typeof(CarriersDbContext))]
    [Migration("20250330130029_InitialCarriers")]
    partial class InitialCarriers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("carriers")
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Modules.Carriers.Domain.Entities.Carrier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_carriers");

                    b.ToTable("carriers", "carriers");
                });

            modelBuilder.Entity("Modules.Carriers.Domain.Entities.CarrierShipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CarrierId")
                        .HasColumnType("uuid")
                        .HasColumnName("carrier_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_id");

                    b.HasKey("Id")
                        .HasName("pk_carrier_shipments");

                    b.HasIndex("CarrierId")
                        .HasDatabaseName("ix_carrier_shipments_carrier_id");

                    b.ToTable("carrier_shipments", "carriers");
                });

            modelBuilder.Entity("Modules.Carriers.Domain.Entities.CarrierShipment", b =>
                {
                    b.HasOne("Modules.Carriers.Domain.Entities.Carrier", "Carrier")
                        .WithMany("Shipments")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carrier_shipments_carriers_carrier_id");

                    b.OwnsOne("Modules.Carriers.Domain.ValueObjects.Address", "ShippingAddress", b1 =>
                        {
                            b1.Property<Guid>("CarrierShipmentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("shipping_address_city");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("shipping_address_street");

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("shipping_address_zip");

                            b1.HasKey("CarrierShipmentId");

                            b1.ToTable("carrier_shipments", "carriers");

                            b1.WithOwner()
                                .HasForeignKey("CarrierShipmentId")
                                .HasConstraintName("fk_carrier_shipments_carrier_shipments_id");
                        });

                    b.Navigation("Carrier");

                    b.Navigation("ShippingAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Modules.Carriers.Domain.Entities.Carrier", b =>
                {
                    b.Navigation("Shipments");
                });
#pragma warning restore 612, 618
        }
    }
}
