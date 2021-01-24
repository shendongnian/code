    [RoutePrefix("api/webhook")]
    public class WebhookController : ApiController
    {
        [HttpPost]
        [Route("")]
        public void Post(Message message)
        {
            Console.WriteLine($"Received webhook: {message.Current.Title} {message.Current.Status}");            
        }
    }
