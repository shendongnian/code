    public IActionResult Get(string name = _defaultName)
    {
        // Don't await or run CPU intensive stuff via Task.Run
        var result = SomeCpuIntensiveOperation();
        return Ok(result);
    }
