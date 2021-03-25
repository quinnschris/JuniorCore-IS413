using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment9Movies.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
