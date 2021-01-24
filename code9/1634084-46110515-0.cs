    public class DivisionController: ApiController
    {
    	private readonly ICalcService _calcService;
    
    	public DivisionController(ICalcService calcService)
    	{
    		_calcService = calcService;
    	}
    	
    	[HttpGet]     
    	public IHttpActionResult div(int a, int b)
    	{
    		return Ok(_calcService.Divide(a,b));
    	}
    }
    
    
    public class CalcService: ICalcService
    {
    	public decimal Divide(int a, int b)
    	{
    		if(b == 0)
    		{
    			//handle what to do if it's zero division, perhaps throw exception
    			return 0;
    		}
    		
    		return a / b;
    	}
    }
