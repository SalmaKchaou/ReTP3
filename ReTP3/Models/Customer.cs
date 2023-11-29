namespace ReTP3.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MemberShipId { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public ICollection<Movie>? Movies { get; set; }
      
    }
}
