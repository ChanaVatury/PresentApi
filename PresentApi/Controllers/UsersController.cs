using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>();
        
        
        // GET: api/<UsersController>
       
 

         [Route("GetUsers")]
        [HttpGet]
        public ICollection<User> GetUsers()
        {
            
            return users;
        }

        [Route("AddUsers")]
        [HttpPost]
        public int AddUsers([FromBody] User user)
        {
            if (users.Count == 0)
            {
                users.Add(new User { Number = 1,UserName = "chana", Password = "chana", FirstName = "chana", LastName = "vatury" }); ;
            }
            if (user.Number <= 0)
            {
                if (users.Count != 0)
                {
                    var max = users.Max(x => x.Number);
                    user.Number = max + 1;
                }
                else
                {
                    user.Number = 2;
                }
            }
            users.Add(user);
            return user.Number;
        }

        [Route("UpdateUsers")]
        [HttpPut]
        public bool UpdateUsers([FromBody] User user)
        {
            var b = users.FirstOrDefault(x => x.Number == user.Number);
            if (b != null)
            {
                b.UserName = user.UserName;
                return true;
            }
            return false;
        }

        [Route("DeleteUsers/{id}")]
        [HttpDelete]
        public bool DeleteUsers(int id)
        {
            var b = users.FirstOrDefault(x => x.Number == id);


            if (b != null)
            {
                users.Remove(b);
                return true;
            }
            return false;
        }

        [Route("Get/{id}")]
        [HttpGet]
        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Number == id);
        }

        [Route("login")]
    
        [HttpPost]
        public User Get([FromBody] User user)
        {
            User p = users.Find(e => e.UserName == user.UserName && e.Password == user.Password);
            if (p != null)
            {
                return p;
            }
            return null;
    
        }
    }
}