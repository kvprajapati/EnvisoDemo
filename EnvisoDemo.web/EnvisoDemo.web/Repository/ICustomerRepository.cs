using EnvisoDemo.web.DBModel;
using EnvisoDemo.web.Models;

namespace EnvisoDemo.web.Repository
{
    public interface ICustomerRepository
    {
        Customer Add(CustomerModel customer);
    }
}
