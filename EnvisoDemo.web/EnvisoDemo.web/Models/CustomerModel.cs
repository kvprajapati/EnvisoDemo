using EnvisoDemo.web.DBModel;

namespace EnvisoDemo.web.Models
{
    public class CustomerModel : Customer
    {
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
