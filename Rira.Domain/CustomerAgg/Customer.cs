namespace Rira.Domain.CustomerAgg
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalNumber { get; set; }
        public DateTime Birthday { get; set; }


        public Customer(string name, string family, string nationalNumber, DateTime birthday)
        {
            Name = name;
            Family = family;
            NationalNumber = nationalNumber;
            Birthday = birthday;
        }

        public void EditCustomer(string name, string family, string nationalNumber, DateTime birthday)
        {
            Name = name;
            Family = family;
            NationalNumber = nationalNumber;
            Birthday = birthday;
        }
    }
    

}
