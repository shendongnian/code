    public async Task<ApiResponseDto> DoSomething(string parameter1, string parameter2, DoSomethingDelegate doMethod) // differing parameters
    {
        try // repeated
        {
           using (var db = new DbContext()) // repeated
           {
             doMethod(parameter1, parameter2, db);
           }   
        }
        catch(Exception e){ // repeated
           HandleServiceLayerException();
        } 
     }
