using CustomerBank.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerBank.Data;
using Microsoft.EntityFrameworkCore;

namespace CustomerBank.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly CustomerStoreContext _context;
        public CustomerService(CustomerStoreContext customer)
        {
            _context = customer;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();

        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(b => b.CustomerId == id);
        }

        public async Task AddCustomer(CustomerModel model)
        {
            await _context.Customer.AddAsync(model);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateCustomer(int id, CustomerModel model)
        {
            var custDB = await _context.Customer.FirstOrDefaultAsync(b => b.CustomerId == id);

            if (custDB != null)
            {
                custDB.FirstName = model.FirstName;
                custDB.LastName = model.LastName;
                custDB.Dob = model.Dob;
                custDB.Email = model.Email;
                custDB.PhoneNumber = model.PhoneNumber;
                custDB.AddressLine1 = model.AddressLine1;
                custDB.AddressLine2 = model.AddressLine2;
                custDB.AddressLine3 = model.AddressLine3;
                custDB.City = model.City;
                custDB.State = model.State;
                custDB.Pincode = model.Pincode;
                custDB.Gender = model.Gender;

            }
        }


        public async Task DeleteCustomer(int id)
        {
            var custDB = await _context.Customer.FirstOrDefaultAsync(b => b.CustomerId == id);
            if(custDB != null)
            {
                _context.Customer.Remove(custDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}
