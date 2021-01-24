    [HttpGet]
    public async Task<IActionResult> DetailsAdmin(int id = 0, [ModelBinder(typeof(PModelBinder))]DateTime? date)
    {
        if (id != 0)
        {
    
        }
        {...}
    }
