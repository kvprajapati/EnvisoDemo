using EnvisoDemo.web.Models;
using EnvisoDemo.web.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EnvisoDemo.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(ICustomerRepository customerRepository,
                                UserManager<IdentityUser> userManager)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("add-customer-license")]
        public async Task<IActionResult> PostCustomer(CustomerModel model)
        {
            model.Role = "Customer";

            var identityUser = new IdentityUser()
            {
                UserName = model.CustomerName,
                Email = model.CustomerEmail
            };
            try
            {
                var result = await _userManager.CreateAsync(identityUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, model.Role);
                    var customerResult = _customerRepository.Add(model);
                    if (customerResult.Id > 0)
                    {
                        return Ok(customerResult);
                    }
                    else
                    {
                        return BadRequest("Customer create failed");
                    }
                }
                else
                {
                    return BadRequest("User create failed");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
