    public IActionResult Get([FromUri] BindingModel bindingModel) {
        List<SomeModel> resultObjects;
    
        [...] // populate resultObjects with data
    
        return Ok(resultObjects);
    }
