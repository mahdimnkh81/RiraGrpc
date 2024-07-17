using Rira.Application.Contract.Customer;
using Rira.Domain.CustomerAgg;

namespace Rira.Infrastructure.EFCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public EditCustomer Update(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(CreateCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
