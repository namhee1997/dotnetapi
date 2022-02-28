using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoaiModels
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { set; get; }
    }
}
