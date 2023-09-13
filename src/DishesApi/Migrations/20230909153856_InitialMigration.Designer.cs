﻿// <auto-generated />
using System;
using DishesAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DishesApi.Migrations
{
    [DbContext(typeof(DishesDbContext))]
    [Migration("20230909153856_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("DishIngredient", b =>
                {
                    b.Property<Guid>("DishesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IngredientsId")
                        .HasColumnType("TEXT");

                    b.HasKey("DishesId", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("DishIngredient");

                    b.HasData(
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("937b1ba1-7969-4324-9ab5-afb0e4d875e6")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("7a2fbc72-bb33-49de-bd23-c78fceb367fc")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("b5f336e2-c226-4389-aac3-2499325a3de9")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe")
                        },
                        new
                        {
                            DishesId = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            IngredientsId = new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d")
                        },
                        new
                        {
                            DishesId = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            IngredientsId = new Guid("aab31c70-57ce-4b6d-a66c-9c1b094e915d")
                        },
                        new
                        {
                            DishesId = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            IngredientsId = new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f")
                        },
                        new
                        {
                            DishesId = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            IngredientsId = new Guid("8d5a1b40-6677-4545-b6e8-5ba93efda0a1")
                        },
                        new
                        {
                            DishesId = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            IngredientsId = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe")
                        },
                        new
                        {
                            DishesId = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            IngredientsId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("40563e5b-e538-4084-9587-3df74fae21d4")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("f350e1a0-38de-42fe-ada5-ae436378ee5b")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("b617df23-3d91-40e1-99aa-b07d264aa937")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("ecd396c3-4403-4fbf-83ca-94a8e9d859b3")
                        },
                        new
                        {
                            DishesId = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            IngredientsId = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("c2c75b40-2453-416e-a7ed-3505b121d671")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("047ab5cc-d041-486e-9d22-a0860fb13237")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("e0017fe1-773f-4a59-9730-9489833c6e8e")
                        },
                        new
                        {
                            DishesId = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            IngredientsId = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("c9b46f9c-d6ce-42c3-8736-2cddbbadee10")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("a07cde83-3127-45da-bbd5-04a7c8d13aa4")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("ebe94d5d-2ad8-4886-b246-05a1fad83d1c")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("40563e5b-e538-4084-9587-3df74fae21d4")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("c2c75b40-2453-416e-a7ed-3505b121d671")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("047ab5cc-d041-486e-9d22-a0860fb13237")
                        },
                        new
                        {
                            DishesId = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            IngredientsId = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe")
                        });
                });

            modelBuilder.Entity("DishesAPI.Entities.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"),
                            Name = "Flemish Beef stew with chicory"
                        },
                        new
                        {
                            Id = new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"),
                            Name = "Mussels with french fries"
                        },
                        new
                        {
                            Id = new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"),
                            Name = "Ragu alla bolognaise"
                        },
                        new
                        {
                            Id = new Guid("fd630a57-2352-4731-b25c-db9cc7601b16"),
                            Name = "Rendang"
                        },
                        new
                        {
                            Id = new Guid("98929bd4-f099-41eb-a994-f1918b724b5a"),
                            Name = "Fish Masala"
                        });
                });

            modelBuilder.Entity("DishesAPI.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Name = "Beef"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Name = "Onion"
                        },
                        new
                        {
                            Id = new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40"),
                            Name = "Dark beer"
                        },
                        new
                        {
                            Id = new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"),
                            Name = "Brown piece of bread"
                        },
                        new
                        {
                            Id = new Guid("937b1ba1-7969-4324-9ab5-afb0e4d875e6"),
                            Name = "Mustard"
                        },
                        new
                        {
                            Id = new Guid("7a2fbc72-bb33-49de-bd23-c78fceb367fc"),
                            Name = "Chicory"
                        },
                        new
                        {
                            Id = new Guid("b5f336e2-c226-4389-aac3-2499325a3de9"),
                            Name = "Mayo"
                        },
                        new
                        {
                            Id = new Guid("c22bec27-a880-4f2a-b380-12dcd99c61fe"),
                            Name = "Various spices"
                        },
                        new
                        {
                            Id = new Guid("aab31c70-57ce-4b6d-a66c-9c1b094e915d"),
                            Name = "Mussels"
                        },
                        new
                        {
                            Id = new Guid("fef8b722-664d-403f-ae3c-05f8ed7d7a1f"),
                            Name = "Celery"
                        },
                        new
                        {
                            Id = new Guid("8d5a1b40-6677-4545-b6e8-5ba93efda0a1"),
                            Name = "French fries"
                        },
                        new
                        {
                            Id = new Guid("40563e5b-e538-4084-9587-3df74fae21d4"),
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = new Guid("f350e1a0-38de-42fe-ada5-ae436378ee5b"),
                            Name = "Tomato paste"
                        },
                        new
                        {
                            Id = new Guid("d5cad9a4-144e-4a3d-858d-9840792fa65d"),
                            Name = "Bay leave"
                        },
                        new
                        {
                            Id = new Guid("b617df23-3d91-40e1-99aa-b07d264aa937"),
                            Name = "Carrot"
                        },
                        new
                        {
                            Id = new Guid("b8b9a6ae-9bcc-4fb3-b883-5974e04eda56"),
                            Name = "Garlic"
                        },
                        new
                        {
                            Id = new Guid("ecd396c3-4403-4fbf-83ca-94a8e9d859b3"),
                            Name = "Red wine"
                        },
                        new
                        {
                            Id = new Guid("c2c75b40-2453-416e-a7ed-3505b121d671"),
                            Name = "Coconut milk"
                        },
                        new
                        {
                            Id = new Guid("3bd3f0a1-87d3-4b85-94fa-ba92bd1874e7"),
                            Name = "Ginger"
                        },
                        new
                        {
                            Id = new Guid("047ab5cc-d041-486e-9d22-a0860fb13237"),
                            Name = "Chili pepper"
                        },
                        new
                        {
                            Id = new Guid("e0017fe1-773f-4a59-9730-9489833c6e8e"),
                            Name = "Tamarind paste"
                        },
                        new
                        {
                            Id = new Guid("c9b46f9c-d6ce-42c3-8736-2cddbbadee10"),
                            Name = "Firm fish"
                        },
                        new
                        {
                            Id = new Guid("a07cde83-3127-45da-bbd5-04a7c8d13aa4"),
                            Name = "Ginger garlic paste"
                        },
                        new
                        {
                            Id = new Guid("ebe94d5d-2ad8-4886-b246-05a1fad83d1c"),
                            Name = "Garam masala"
                        });
                });

            modelBuilder.Entity("DishIngredient", b =>
                {
                    b.HasOne("DishesAPI.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DishesAPI.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
