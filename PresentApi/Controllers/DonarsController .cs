using Microsoft.AspNetCore.Mvc;
using PresentApi;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarsController : ControllerBase
    {
        static List<Donars> donars = new List<Donars>();

        [Route("GetDonars")]
        [HttpGet]
        public List<Donars> GetDonars()
{
    if (donars.Count == 0)
    {
                donars.Add(new Donars { Number= 1, Name=  "Bil gates" });
                donars.Add(new Donars { Number= 2, Name = "Rothchild" });
                donars.Add(new Donars { Number= 3, Name = "Elan musk" });
                donars.Add(new Donars { Number= 4, Name = "Inside" });
                donars.Add(new Donars { Number= 5, Name = "miri`s" });
                donars.Add(new Donars { Number= 6, Name = "blew" });
                donars.Add(new Donars { Number= 7, Name = "peek a boo" });
                donars.Add(new Donars { Number= 8, Name = "ronit" });
                donars.Add(new Donars { Number= 9, Name = "Chana Vatury"});
            }
            return donars;
        }

        [Route("AddDonars")]
        [HttpPost]
        public int AddDonars([FromBody] Donars donar)
        {
            if (donar.Number <= 0)
            {
                var max = donars.Max(x => x.Number);
                donar.Number = max + 1;
            }
            donars.Add(donar);
            return donar.Number;
        }

        [Route("UpdateDonars")]
        [HttpPut]
        public bool UpdateDonars([FromBody] Donars donar)
        {
            var b = donars.FirstOrDefault(x => x.Number == donar.Number);
            if (b != null)
            {
                b.Name = donar.Name;
                return true;
            }
            return false;
        }

        [Route("DeleteDonars/{id}")]
        [HttpDelete]
        public bool DeleteDonars(int id)
        {
            var b = donars.FirstOrDefault(x => x.Number == id);
            
            
            if (b != null)
            {
                donars.Remove(b);
                return true;
            }
            return false;
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Donars GetById(int id)
        {
            return donars.FirstOrDefault(x => x.Number == id);
        }
    }
}
