﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMySqlDataMissingAutoIncrementAnnotation;

namespace TestMySqlDataMissingAutoIncrementAnnotation.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("TestMySqlDataMissingAutoIncrementAnnotation.Bar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("BarId");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("TestMySqlDataMissingAutoIncrementAnnotation.Foo", b =>
                {
                    b.Property<int>("FooId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("FooId");

                    b.ToTable("Foos");
                });

            modelBuilder.Entity("TestMySqlDataMissingAutoIncrementAnnotation.Bar", b =>
                {
                    b.OwnsOne("TestMySqlDataMissingAutoIncrementAnnotation.Baz", "Baz", b1 =>
                        {
                            b1.Property<int>("BarId");

                            b1.Property<int>("Data");

                            b1.ToTable("Bars");

                            b1.HasOne("TestMySqlDataMissingAutoIncrementAnnotation.Bar")
                                .WithOne("Baz")
                                .HasForeignKey("TestMySqlDataMissingAutoIncrementAnnotation.Baz", "BarId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("TestMySqlDataMissingAutoIncrementAnnotation.Foo", b =>
                {
                    b.OwnsOne("TestMySqlDataMissingAutoIncrementAnnotation.Baz", "Baz", b1 =>
                        {
                            b1.Property<int>("FooId");

                            b1.Property<int>("Data");

                            b1.ToTable("Foos");

                            b1.HasOne("TestMySqlDataMissingAutoIncrementAnnotation.Foo")
                                .WithOne("Baz")
                                .HasForeignKey("TestMySqlDataMissingAutoIncrementAnnotation.Baz", "FooId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
