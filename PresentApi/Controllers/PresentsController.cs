using Microsoft.AspNetCore.Mvc;
using PresentApi;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentsController : ControllerBase
    {
        static List<Presents> presents = new List<Presents>();

        [Route("GetPresents")]
        [HttpGet]
        public List<Presents> GetPresents()
{
    if (presents.Count == 0)
    {
                presents.Add(new Presents { Number= 1, Name= "1,000,000$", Donar= "Bil gates" , TicketPrice= 500,Image ="/cash.jpg" });
                presents.Add(new Presents { Number= 2, Name = "Apartment in the old city", Donar = "Rothchild", TicketPrice = 500, Image = "/oldcity.jpg" });
                presents.Add(new Presents { Number= 3, Name = "Tesla", Donar = "Elan musk", TicketPrice = 300, Image = "/tesla.jpg" });
                presents.Add(new Presents { Number= 4, Name = "kitchen", Donar = "Inside", TicketPrice = 300, Image = "/kitchen.jpg" });
                presents.Add(new Presents { Number= 5, Name = "wig", Donar = "miri`s", TicketPrice = 200, Image = "/wig.jpg" });
                presents.Add(new Presents { Number= 6, Name = "woman shopping 5000", Donar = "blew", TicketPrice = 100, Image = "/woman.jpg" });
                presents.Add(new Presents { Number= 7, Name = "kids shopping 5000", Donar = "peek a boo", TicketPrice = 100, Image = "/kids.jpg" });
                presents.Add(new Presents { Number= 8, Name = "gold watch", Donar = "ronit", TicketPrice = 50, Image = "/watch.jpg" });
                presents.Add(new Presents { Number= 9, Name = "Muchamad Def", Donar = "Chana Vatury", TicketPrice = 10000000, Image = "" });
            }
            return presents;
        }

        [Route("AddPresents")]
        [HttpPost]
        public int AddPresents([FromBody] Presents present)
        {
            if (present.Number <= 0)
            {
                var max = presents.Max(x => x.Number);
                present.Number = max + 1;
            }
            presents.Add(present);
            return present.Number;
        }

        [Route("UpdatePresents")]
        [HttpPut]
        public bool UpdatePresents([FromBody] Presents present)
        {
            var b = presents.FirstOrDefault(x => x.Number == present.Number);
            if (b != null)
            {
                b.Name = present.Name;
                b.TicketPrice = present.TicketPrice;
                return true;
            }
            return false;
        }

        [Route("DeletePresents/{id}")]
        [HttpDelete]
        public bool DeletePresents(int id)
        {
            var b = presents.FirstOrDefault(x => x.Number == id);
            
            
            if (b != null)
            {
                presents.Remove(b);
                return true;
            }
            return false;
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Presents GetById(int id)
        {
            return presents.FirstOrDefault(x => x.Number == id);
        }
    }
}
