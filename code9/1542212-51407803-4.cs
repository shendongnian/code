    public async Task OnExceptionAsync(ExceptionContext context)
    {
        //...
        await response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(exObj))
    }
