using Rira.Application.Contract.Customer;

namespace Rira.Domain.CustomerAgg
{
    public interface ICustomerRepository
    {
        Task<Customer> GetBy(int id);
        Task Create(Customer customer);
        Task<EditCustomer> Update(EditCustomer edit);
        Task<int> Delete(int id);
        Task <List<CustomerViewModel>> GetAll();




    }
}