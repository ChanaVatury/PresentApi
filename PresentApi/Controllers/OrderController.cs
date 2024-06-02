using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static List<Order> orders = new List<Order>();


        [Route("GetOrders")]
        [HttpGet]
        public ICollection<Order> GetOrders()
        {

            return orders;
        }

        [Route("createOrder")]
        [HttpPost]
        public Order Post([FromBody] Order order)
        {
                if (order.Id <= 0)
                {
                    if (orders.Count != 0)
                    {
                        var max = orders.Max(x => x.Id);
                        order.Id = max + 1;
                    }
                    else
                    {
                        order.Id = 1;
                    }
                }
                orders.Add(order);
                return order;
            }
    }
}
