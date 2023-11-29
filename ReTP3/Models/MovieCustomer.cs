namespace ReTP3.Models
{
    public class MovieCustomer
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
