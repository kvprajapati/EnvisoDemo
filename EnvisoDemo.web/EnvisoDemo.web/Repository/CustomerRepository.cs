using EnvisoDemo.web.DBModel;
using EnvisoDemo.web.Models;
using Microsoft.Extensions.Logging;

namespace EnvisoDemo.web.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AppDbContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Customer Add(CustomerModel model)
        {
            var customer = new Customer
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                DateOfBirth = model.DateOfBirth,
                ExpiredDate = model.ExpiredDate,
                UserId = model.UserId,
                LicenseType = model.LicenseType
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
