    [HttpPost("FormProcWithModels")]
    public IActionResult Contact(FormCollection Fc)
    {
        var UserName = Fc["UserName"].ToString();
    
        return Content($"The form username entered is {UserName}");
    }
