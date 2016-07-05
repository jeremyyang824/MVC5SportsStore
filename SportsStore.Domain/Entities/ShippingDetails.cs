using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入地址行1")]
        [Display(Name = "地址行1")]
        public string Line1 { get; set; }

        [Display(Name = "地址行2")]
        public string Line2 { get; set; }

        [Display(Name = "地址行3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "请输入城市名")]
        public string City { get; set; }

        [Required(ErrorMessage = "请输入省名")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "请输入国家名")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
