namespace Rira.Application.Contract.Customer
{
    public interface ICustomerApplication
    {
        CustomerViewModel Get(int id);
        void Create(CreateCustomer customer);
        void Update(EditCustomer edit);
        Task<int> Delete(int id);
        Task<List<CustomerViewModel>> GetAll();
    }
}
