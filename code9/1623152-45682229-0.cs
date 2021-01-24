    [HttpGet]
    [Route("SystemCheck/PulseCheck")]
    public SingleResult<string> PulseCheck()
    {
        var pulseCheck = PulseCheckHelper.PulseCheck();
        return SingleResult.Create(new[]{ pulseCheck }.AsQueryable());
    } 
