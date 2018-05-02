namespace BooksAPI.Core
{
    using System.Data.Entity;
    using BooksAPI.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RedContext : IdentityDbContext
    {
        public RedContext()
            : base("RedContext")
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<RedUser> RedUsers { get; set; }
        public DbSet<VotingPlace> VotingPlaces { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }
}