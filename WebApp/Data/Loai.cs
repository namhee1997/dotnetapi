using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai{ set; get; }

        [Required]
        [MaxLength(50)]
        public string TenLoai{ set; get; }

        public virtual ICollection<HangHoa> HangHoaget { get; set; }
    }
}
