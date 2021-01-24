    public ActionResult ControllerAction() {
        
        // ...
        
        SomePageViewModel viewModel = new SomePageViewModel();
        viewModel.ActionName = entityObject.ActionName;
        
        return this.View( viewModel );
    }
