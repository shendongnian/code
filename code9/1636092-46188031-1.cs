    [HttpPost]
    public IHttpActionResult Foo(FooViewModel model) {
        
        if( !model.IsTermsAccepted ) {
            
            this.ModelState.AddModelError( nameof(model.IsTermsAccepted), "you must accept the terms." );
            return this.View( model );
        }
        
    }
