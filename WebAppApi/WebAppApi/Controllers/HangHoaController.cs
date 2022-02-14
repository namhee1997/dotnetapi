using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Router("api/[Controller]")]
    [ApiController]
    public class HangHoaController:ControllerBase
    {
        public static List<Hanghoa> hanghoa = new List<Hanghoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoa);
        }
        [HttpPost]
        public IActionResult Create(Hanghoa hanghoa2)
        {
            var hanghoa1 = new Hanghoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoa2.TenHangHoa,
                DonGia = hanghoa2.DonGia,
            };
            hanghoa.Add(hanghoa1);
            return Ok(new
            {
                Success = true,Data = hanghoa1
            });;
        }

    }
}
