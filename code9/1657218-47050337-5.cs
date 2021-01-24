    public class AdditionController : ApiController
{
    private RestfulClient restfulClient = new RestfulClient();
    public IHttpActionResult Get(int firstNumber, int secondNumber)
    {
        //What do i have to include here?
        //Tried
        var result = restfulClient.addition(firstNumber, secondNumber).Result; 
        return Json(result);
    }
