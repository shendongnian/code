    [Route("api/[controller]")]
    public class RestController : Controller {
        private readonly IRabbitMQConnectionFactory factory;
    
        public RestController(IRabbitMQConnectionFactory factory) {
            this.factory = factory;
        }
    
        [HttpPost]
        public IActionResult Push([FromBody] OrderItem orderItem) {
            try {                
                using (var connection = factory.CreateConnection()) {
                    var model = connection.CreateModel();
                    var helper = new RabbitMQHelper(model, "Topic_Exchange");
                    helper.PushMessageIntoQueue(orderItem.Serialize(), "Order_Queue");
                    return Ok();
                }
            } catch (Exception) {
                //TODO: Log error message
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }
