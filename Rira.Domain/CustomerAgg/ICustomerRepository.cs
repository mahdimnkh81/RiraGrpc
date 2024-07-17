using Rira.Application.Contract.Customer;

namespace Rira.Domain.CustomerAgg
{
    public interface ICustomerRepository
    {
        Customer GetBy(int id);
        int Create(CreateCustomer customer);
        EditCustomer Update(int id);
        int Delete(int id);
        List<CustomerViewModel> GetAll();




    }
}