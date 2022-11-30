using CustomerBank.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomerBank.Service
{
    public interface ICustomerService
    {
        Task <IEnumerable<CustomerModel>> GetCustomers();
        Task<CustomerModel> GetCustomerById(int id);
        Task UpdateCustomer(int id, CustomerModel model);
        Task AddCustomer(CustomerModel model);
        Task DeleteCustomer(int id);
    }
}
