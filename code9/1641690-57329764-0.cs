    public class TicketController : ApiController
    {
     private readonly TicketService _svcTicket;
     public TicketController()
     {
           try
           {
              if(tokenIsManipulated) {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("Access Token is manipulated")
                    });
              }
            }
            catch(HttpResponseException)
            {
                throw;
            }
       }
    }
