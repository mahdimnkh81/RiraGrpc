namespace Rira.Application.Contract.Customer
{
    public class CreateCustomer
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
