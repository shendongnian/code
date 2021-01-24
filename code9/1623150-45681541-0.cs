    [HttpGet]
    [Route("SystemCheck/PulseCheck")]
    public object PulseCheck()
    {
       var pulseCheck = PulseCheckHelper.PulseCheck();
       return new { PulseCheck = pulseCheck };
    }
