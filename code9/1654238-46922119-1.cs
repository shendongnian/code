    public class Context
    {
         [ThreadStatic]
         private static LogStore _store; 
         
         public static Log(....)
         {
             .....
         } 
    }
-------------
    public void ViewMethod()
    {
        
        var response = BussinessMethod();           
        if (response.Status = ResponseStatus.Success)
            // do something with response.Data
        else
            // show message?
    }
    public BusinessMethodResponse BussinessMethod()
    {
        
        var response = new BusinessMethodResponse() {Status = ResponseStatus.Failure};
        SomeData data;
        try
        {
            data = DataAcessMethod();
        }
        catch (Exception ex)
        {
            Context.Log(....);
            response.Message = "Data retrieval failed";
            return response;
        }
        try
        {
            // massage the data here
            response.Status = ResponseStatus.Success;
            response.Data = myMassagedData;
        }
        catch (Exception ex)
        {
             Context.Log(....);
             response.Message = "Something failed";
        }
        
        return response;
    }
    public void DataAcessMethod()
    {
        // some code that executes an SQL command
    }
