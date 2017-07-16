using System;
using DrinkSuggestions.DAL;
using DrinkSuggestions.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DrinkSuggestions.Tests
{
    public class DrinksContextTest
    {
        private DrinksContext GetDrinksContext()
        {
            var options = new DbContextOptionsBuilder<DrinksContext>()
                .UseInMemoryDatabase(databaseName: "drinks_test_db")
                .Options;

            return new DrinksContext(options);
        }

        private Drink GetTestDrink()
        {
            return new Drink(){Name = "Test Drink 1", Description = "This drink is just a test."};
        }

        private Ingredient GetTestIngredient()
        {
            return new Ingredient(){Name = "Test Ingredient"};
        }

        [Fact]
        public void ShouldAddDrinkToDatabase()
        {
            var context = GetDrinksContext();
            var drink = GetTestDrink();
            context.Add(drink);
            context.SaveChanges();
        }
        [Fact]
        public void ShouldAddIngredientToDatabase()
        {
            var context = GetDrinksContext();
            var ingredient = GetTestIngredient();
            context.Add(ingredient);
            context.SaveChanges();
        }
    }
}