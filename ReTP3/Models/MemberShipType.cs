namespace ReTP3.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SignUpFee { get; set; }
        public int DurationMonth { get; set; }
        public int DiscountRate { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
