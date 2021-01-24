    public sealed class APIResponse<T>
    {
        IAPIError Error { get; set; }        
        T Results { get; set; }
    }
    public async Task<IActionResult> Get()
    {
        var response = new ApiResponse<<IEnumerable<User>>>();
        try
        {
            var data = await _someService.GetAll();
            response.Result = data;
            return Ok(response);//returns 200 status code
        }
        catch (Exception ex)
        {
            response.Error = new APIError(ex.Message, 500);
            return BadRequrest(response);
        }            
    }  
