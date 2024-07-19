using Rira.Application.Contract.Customer;
using Rira.Domain.CustomerAgg;

namespace Rira.Application
{
    public class CustomerApplication : ICustomerApplication
    {
        public ICustomerRepository customerRepository { get; set; }

        public CustomerApplication(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        public CustomerViewModel Get(int id)
        {
            var customer = customerRepository.GetBy(id);
            return new CustomerViewModel
            {
                Id = customer.Result.Id,
                Name = customer.Result.Name,
                Family = customer.Result.Family,
                NationalNumber = customer.Result.NationalNumber,
                Birthday = customer.Result.Birthday
            };
        }

        public void Create(CreateCustomer createCustomer)
        {
            var cus = new Customer(createCustomer.Name, createCustomer.Family, createCustomer.NationalNumber, createCustomer.Birthday);

            customerRepository.Create(cus);
        }

        public void Update(EditCustomer edit)
        {
            customerRepository.Update(edit);
        }

        public Task<int> Delete(int id)
        {
            return customerRepository.Delete(id);
        }

        public  async Task<List<CustomerViewModel>> GetAll()
        {
            return await customerRepository.GetAll();
          

        }
    }
}