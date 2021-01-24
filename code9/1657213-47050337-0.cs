    public class AdditionController : ApiController
{
    private RestfulClient restfulClient = new RestfulClient();
    public IHttpActionResult Get(int firstNumber, int secondNumber)
    {
        SumModel sumModel = new SumModel(firstNumber, secondNumber);
        return Ok(sumModel);
    }
