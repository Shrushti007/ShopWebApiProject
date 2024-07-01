using System.ComponentModel.DataAnnotations;

namespace ShopWebApiProject.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public List<Order> Orders { get; set; }
    }
}
