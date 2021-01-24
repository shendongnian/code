    [Route("api/dlladdition/{num1}/{num2}")]
    public IHttpActionResult GET(int num1, int num2)
    {
        var res = ClassLibraryDll.MathClass.Add(num1, num2);
        return Ok(new {result = res});
    }
