using Microsoft.EntityFrameworkCore;
namespace ReTP3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<MemberShipType> memberships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string genresJson = File.ReadAllText("Data/Genre.json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(genresJson);

            if (genres == null)
            {
                return;
            }

            foreach (var genre in genres)
            {
                modelBuilder
                    .Entity<Genre>()
                    .HasData(genre);
            }
        }
        

    }
}
