namespace Rira.Application.Contract.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}