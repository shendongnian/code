    CustomResponseMessage message = new CustomResponseMessage()
    {
       Message = "write a something"
    };
    Request.CreateResponse(HttpStatusCode.Ok,message);
    //Custom Class
    public class CustomResponseMessage
    {
       public string Message{ get; set; }
    }
