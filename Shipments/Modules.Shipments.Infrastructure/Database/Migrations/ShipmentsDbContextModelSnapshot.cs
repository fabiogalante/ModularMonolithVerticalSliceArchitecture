﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.Shipments.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.Shipments.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ShipmentsDbContext))]
    partial class ShipmentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("shipments")
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Modules.Shipments.Domain.Entities.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Carrier")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("carrier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("order_id");

                    b.Property<string>("ReceiverEmail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_email");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_shipments");

                    b.HasIndex("Number")
                        .HasDatabaseName("ix_shipments_number");

                    b.ToTable("shipments", "shipments");
                });

            modelBuilder.Entity("Modules.Shipments.Domain.Entities.ShipmentItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<Guid>("ShipmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("shipment_id");

                    b.HasKey("Id")
                        .HasName("pk_shipment_items");

                    b.HasIndex("ShipmentId")
                        .HasDatabaseName("ix_shipment_items_shipment_id");

                    b.ToTable("shipment_items", "shipments");
                });

            modelBuilder.Entity("Modules.Shipments.Domain.Entities.Shipment", b =>
                {
                    b.OwnsOne("Modules.Shipments.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ShipmentId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.Property<string>("Zip")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_zip");

                            b1.HasKey("ShipmentId");

                            b1.ToTable("shipments", "shipments");

                            b1.WithOwner()
                                .HasForeignKey("ShipmentId")
                                .HasConstraintName("fk_shipments_shipments_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("Modules.Shipments.Domain.Entities.ShipmentItem", b =>
                {
                    b.HasOne("Modules.Shipments.Domain.Entities.Shipment", "Shipment")
                        .WithMany("Items")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipment_items_shipments_shipment_id");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Modules.Shipments.Domain.Entities.Shipment", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
