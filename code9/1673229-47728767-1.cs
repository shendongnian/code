    [RoutePrefix("api/webhook")]
    public class WebhookController : ApiController
    {
        [HttpPost]
        [Route("")]
        public void Post(Message message)
        {
            Console.WriteLine($"Received webhook: {message.Title} {message.Status}");            
        }
    }
