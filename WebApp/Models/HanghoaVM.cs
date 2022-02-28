using System;

namespace WebApp.Models
{
    public class HanghoaVM
    {
        public string TenHangHoa { set; get; }
        public double Dongia { set; get; }
    }
    public class Hanghoa : HanghoaVM
    {
        public Guid MaHangHoa { set; get; }
    }
}
