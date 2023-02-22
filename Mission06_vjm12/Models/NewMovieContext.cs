using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_vjm12.Models
{
    public class NewMovieContext : DbContext
    {
        //Constructor for inherited context class
        public NewMovieContext (DbContextOptions<NewMovieContext> options) : base(options)
        {
            //Leave blank for now. Important thing is the inheritance is set up
        }
        public DbSet<NewMovie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //Seed database with three movies using json objects
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName="Action"},
                new Category { CategoryID=2, CategoryName="Adventure"},
                new Category { CategoryID=3, CategoryName="Animation"},
                new Category { CategoryID=4, CategoryName="Comedy"},
                new Category { CategoryID=5, CategoryName="Drama"},
                new Category { CategoryID = 6, CategoryName = "Fantasy" },
                new Category { CategoryID = 7, CategoryName = "Horror" },
                new Category { CategoryID = 8, CategoryName = "Musical" },
                new Category { CategoryID = 9, CategoryName = "Mystery" },
                new Category { CategoryID = 10, CategoryName = "Romance" },
                new Category { CategoryID = 11, CategoryName = "Science Fiction" },
                new Category { CategoryID = 12, CategoryName = "Sports" },
                new Category { CategoryID = 13, CategoryName = "Thriller" },
                new Category { CategoryID = 14, CategoryName = "Western" }

                );
            mb.Entity<NewMovie>().HasData(
                new NewMovie
                {
                    MovieID = 1,
                    CategoryID = 2,
                    MovieTitle = "The Princess Bride",
                    Year = 1987,
                    Director = "Rob Reiner",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new NewMovie
                {
                    MovieID = 2,
                    CategoryID = 2,
                    MovieTitle = "The Great Race",
                    Year = 1965,
                    Director = "Blake Edwards",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                },
                new NewMovie
                {
                    MovieID = 3,
                    CategoryID = 3,
                    MovieTitle = "How To Train Your Dragon",
                    Year = 2010,
                    Director = "Dean DeBlois, Chris Sanders",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "",
                }
            );
        }
    }

}
