using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<Hanghoa> hanghoas = new List<Hanghoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(e => e.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HanghoaVM hanghoaVM)
        {
            var hanghoa = new Hanghoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                Dongia = hanghoaVM.Dongia
            };
            hanghoas.Add(hanghoa);
            return Ok(
                new { success = true, Data = hanghoa }
                );
        }
        [HttpPut("{id}")]
        public IActionResult EditPost(string id, Hanghoa hanghoaedit)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(e => e.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                //CHECKID
                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                //UPDATE
                hangHoa.TenHangHoa = hanghoaedit.TenHangHoa;
                hangHoa.Dongia = hanghoaedit.Dongia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePost(string id, Hanghoa hanghoaedit)
        {
            try
            {
                var hangHoa = hanghoas.SingleOrDefault(e => e.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }


                //delete
                hanghoas.Remove(hangHoa);


                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
