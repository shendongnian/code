    public List<SomeModel> get()
    {
       ... 
       ... // check logic
       ...
       Response.StatusCode = 403;
       return new List<SomeModel>();
    }
