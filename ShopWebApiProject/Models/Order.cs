using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShopWebApiProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderAmt { get; set; }
        public string OrderStatus { get; set; }

       
        public int UserId { get; set; }


        [ForeignKey("UserId")]
        [JsonIgnore]
        public User User { get; set; }


    }
}
