using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Rira.Application.Contract.Customer;
using Rira.Domain.CustomerAgg;

namespace Rira.Infrastructure.EFCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetBy(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                throw new Exception($"No Task with Id {id}");
            return customer;
        }

        public async Task<EditCustomer> Update(EditCustomer edit)
        {
            var customer = _context.Customers.Find(edit.Id);
            if (customer == null)
                throw new Exception($"No Task with Id {edit.Id}");
            customer.Name = edit.Name;
            customer.Family = edit.Family;
            customer.NationalNumber = edit.NationalNumber;
            customer.Birthday = edit.Birthday;
            _context.SaveChanges();

            return new EditCustomer()
            {
                Id = edit.Id,
                Name = edit.Name,
                Family = edit.Family,
                NationalNumber = edit.NationalNumber,
                Birthday = edit.Birthday
            };
        }

        public async Task<int> Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                throw new Exception($"No Task with Id {id}");
            var deleteCustomer = _context.Customers.Remove(customer);
            _context.SaveChanges();
            return deleteCustomer.Entity.Id;
        }

        public async Task<List<CustomerViewModel>> GetAll()
        {
            var customers = await _context.Customers.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Family = x.Family,
                NationalNumber = x.NationalNumber,
                Birthday = x.Birthday
            }).ToListAsync();

            return customers;
        }

        public async Task Create(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }
    }
}