    public class WeatherChannelWrapper : IWeatherServiceWrapper
    {
        private readonly IExceptionLogger exceptionLogger;
    
        public WeatherChannelWrapper(IExceptionLogger logger)
        {
            this.exceptionLogger = logger;
        }
    	
        public GetLocalWeather(string zipcode)
        {
            try 
            {
                CallTwcProxy(zipcode);
            }
            catch (Exception e)
            {
                exceptionLogger.Log(e);
            }
        }
    	
    	protected virtual void CallTwcProxy(string zipcode)
    	{
    		TWCProxy.GetCurrentCondition(zipcode, DateTime.Now.ToString("MM/dd/yyyy hh:mm"));
    	}
    }
