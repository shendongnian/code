        [Authorize]
        [Route("api/[controller]")]
        public class WSController : Controller
        {           
            [HttpGet]
            public async Task Get()
            {
                var context = ControllerContext.HttpContext;    
                WebSocket currentSocket = await context.WebSockets.AcceptWebSocketAsync("client"); // it's important to make sure the response returns the same subprotocol
               // ...
        }
