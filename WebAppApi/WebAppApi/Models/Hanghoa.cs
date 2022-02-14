using System;

namespace WebAppApi.Models
{
    public class HanghoaVM
    {
        public string TenHangHoa { get;set; }
        public double DonGia { get;set; }
    }
    public class Hanghoa : HanghoaVM
    {
        public Guid MaHangHoa { set; get; }
    }
}
