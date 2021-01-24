    public async Task OnException(ExceptionContext context)
    {
        //...
        await response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(exObj))
    }
