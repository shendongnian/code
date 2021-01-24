    [HttpPost("/Utilities/Tool/{type}/{process}")]
    public IActionResult ToolProcess([FromBody] ToolModel model,  string process)
    {
        var test = model.text;
        var result = model;
        // to do : Add your custom code here
        return Ok(result);
    }
