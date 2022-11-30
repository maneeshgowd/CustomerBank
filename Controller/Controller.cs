using CustomerBank.Model;
using CustomerBank.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerBank.Controller
{

    [ApiController]
    [Route("api/v1/customer-details")]
    public class Controller : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly IAccountService _account;

        public Controller(ICustomerService customer, IAccountService account)
        {
            _customer = customer;
            _account = account;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomerAsync(){
            return Ok(await _customer.GetCustomers());
        }

        //public async Task<ActionResult> UpdateCustomerAsync(int id, CustomerModel customer)
        //{
        //    return Ok(await _customer.UpdateCustomer(int id, CustomerModel customer));
        //}

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(CustomerModel customer)
        {
            await _customer.AddCustomer(customer);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCustomerAsync(int id)
        {
            return Ok(await _customer.GetCustomerById(id));
        }
    }
}
