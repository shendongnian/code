    public ActionResult Foo( YourModel model )
    {
        // manual validation
        if ( ... )
           ModelState.AddModelError( key, error );
        if ( ModelState.IsValid ) // this works too
           ...
