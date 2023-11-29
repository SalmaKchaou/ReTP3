using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReTP3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime MovieAdded { get; set; } = DateTime.Now;
        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
