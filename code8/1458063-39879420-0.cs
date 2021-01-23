    [HttpPost("{id:int}/bar")]
    public void Foo()
    {
        int id = Int32.Parse((string)RouteData.Values["id"]);
        
        // ...
    }
