    public class MyApiClient : BaseHttpClient, IMyApiClient
    {
    	public MyApiClient() : base(ConfigurationManager.AppSettings["WebApiUrl"])
    	{
    	}
    
    	public ReturnDTO<ResponseDTO> MyMethod(FilterDTO filter)
    	{
    		return this.ExecutePost<FilterDTO, ReturnDTO<ResponseDTO>>("YourWebApiURL", filter);
    	}
    
    }
