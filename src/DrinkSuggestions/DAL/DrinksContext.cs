using DrinkSuggestions.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkSuggestions.DAL
{
    public class DrinksContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DrinksContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>( entity => 
            {
                entity.ToTable("Drinks");
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Id)
                    .ValueGeneratedOnAdd();
                
                entity.Property(d => d.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(d => d.Description)
                    .HasMaxLength(500);

                entity.HasIndex(d => d.Name);
            });

            modelBuilder.Entity<Ingredient>( entity => 
            {
                entity.ToTable("Ingredients");
                entity.HasKey(i => i.Id);

                entity.Property(i => i.Id)
                    .ValueGeneratedOnAdd();
                
                entity.Property(i => i.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.HasIndex(i => i.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<DrinkIngredient>( entity => 
            {
                entity.ToTable("DrinkIngredients");
                entity.HasKey(di => new {di.DrinkId, di.IngredientId});

                entity.Property(di => di.DrinkId)
                    .IsRequired();
                entity.Property(di => di.IngredientId)
                    .IsRequired();
                entity.Property(di => di.Amount)
                    .IsRequired();

                entity.HasOne(di => di.Drink)
                    .WithMany(d => d.DrinkIngredients)
                    .HasForeignKey(di => di.DrinkId);

                entity.HasOne(di => di.Ingredient)
                    .WithMany(i => i.DrinkIngredients)
                    .HasForeignKey(di => di.IngredientId);

                entity.HasIndex(di => di.DrinkId);
            });
        }
    }
}