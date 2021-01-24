    [Audit(ActionType.EntityTop)]
    [HttpGet("top/{top:int}")] //you can specify route via Annotations
    public IActionResult GetEntities(int top)
    {
        // ...
    }
