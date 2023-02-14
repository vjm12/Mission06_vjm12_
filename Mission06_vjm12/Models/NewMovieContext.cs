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
        //Seed database with three movies using json objects
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovie>().HasData(
                new NewMovie
                {
                    MovieID = 1,
                    Category = "Romance/Adventure",
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
                    Category = "Comedy/Romance",
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
                    Category = "Family/Adventure",
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
