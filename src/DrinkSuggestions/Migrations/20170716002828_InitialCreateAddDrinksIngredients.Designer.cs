using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DrinkSuggestions.DAL;

namespace DrinkSuggestions.Migrations
{
    [DbContext(typeof(DrinksContext))]
    [Migration("20170716002828_InitialCreateAddDrinksIngredients")]
    partial class InitialCreateAddDrinksIngredients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DrinkSuggestions.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("DrinkSuggestions.Models.DrinkIngredient", b =>
                {
                    b.Property<int>("DrinkId");

                    b.Property<int>("IngredientId");

                    b.Property<string>("Amount")
                        .IsRequired();

                    b.HasKey("DrinkId", "IngredientId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DrinkIngredients");
                });

            modelBuilder.Entity("DrinkSuggestions.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("DrinkSuggestions.Models.DrinkIngredient", b =>
                {
                    b.HasOne("DrinkSuggestions.Models.Drink", "Drink")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DrinkSuggestions.Models.Ingredient", "Ingredient")
                        .WithMany("DrinkIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
