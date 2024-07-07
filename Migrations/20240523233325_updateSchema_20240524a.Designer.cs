﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisentiaTwin_API.DataContexts;

#nullable disable

namespace VisentiaTwin_API.Migrations
{
    [DbContext(typeof(VTSystemContext))]
    [Migration("20240523233325_updateSchema_20240524a")]
    partial class updateSchema_20240524a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VTNodeId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estimatorString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VTNodeId");

                    b.ToTable("VTComponents");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SelectedComponentId")
                        .HasColumnType("int");

                    b.Property<int?>("VTSystemId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SelectedComponentId");

                    b.HasIndex("VTSystemId");

                    b.ToTable("VTNodes");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTNodeComponent", b =>
                {
                    b.Property<int>("VTNodeId")
                        .HasColumnType("int");

                    b.Property<int>("VTComponentId")
                        .HasColumnType("int");

                    b.HasKey("VTNodeId", "VTComponentId");

                    b.HasIndex("VTComponentId");

                    b.ToTable("VTNodeComponents");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estimatorString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VTSystems");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTComponent", b =>
                {
                    b.HasOne("VisentiaTwin_API.DataModels.VTNode", null)
                        .WithMany("VTNodeOptions")
                        .HasForeignKey("VTNodeId");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTNode", b =>
                {
                    b.HasOne("VisentiaTwin_API.DataModels.VTComponent", "SelectedComponent")
                        .WithMany()
                        .HasForeignKey("SelectedComponentId");

                    b.HasOne("VisentiaTwin_API.DataModels.VTSystem", "VTSystem")
                        .WithMany("VTNodes")
                        .HasForeignKey("VTSystemId");

                    b.Navigation("SelectedComponent");

                    b.Navigation("VTSystem");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTNodeComponent", b =>
                {
                    b.HasOne("VisentiaTwin_API.DataModels.VTComponent", "VTComponent")
                        .WithMany("VTNodeComponents")
                        .HasForeignKey("VTComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisentiaTwin_API.DataModels.VTNode", "VTNode")
                        .WithMany("VTNodeComponents")
                        .HasForeignKey("VTNodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VTComponent");

                    b.Navigation("VTNode");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTComponent", b =>
                {
                    b.Navigation("VTNodeComponents");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTNode", b =>
                {
                    b.Navigation("VTNodeComponents");

                    b.Navigation("VTNodeOptions");
                });

            modelBuilder.Entity("VisentiaTwin_API.DataModels.VTSystem", b =>
                {
                    b.Navigation("VTNodes");
                });
#pragma warning restore 612, 618
        }
    }
}
