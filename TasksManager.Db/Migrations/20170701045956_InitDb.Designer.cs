using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TasksManager.Db;
using TasksManager.Entities;

namespace TasksManager.Db.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20170701045956_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TasksManager.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2048);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TasksManager.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TasksManager.Entities.TagsInTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TagId");

                    b.Property<int>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("TaskId");

                    b.ToTable("TagsInTasks");
                });

            modelBuilder.Entity("TasksManager.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CompleteDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(4096);

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("ProjectId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TasksManager.Entities.TagsInTask", b =>
                {
                    b.HasOne("TasksManager.Entities.Tag", "Tag")
                        .WithMany("Tasks")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TasksManager.Entities.Task", "Task")
                        .WithMany("Tags")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TasksManager.Entities.Task", b =>
                {
                    b.HasOne("TasksManager.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
