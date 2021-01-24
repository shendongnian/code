    public override void ViewWillLayoutSubviews()
    {
        base.ViewWillLayoutSubviews();
    
        var master = ViewControllers[0];
        master.View.BackgroundColor = UIColor.Clear;
    
        //This is Detail ViewController
        var detail = ViewController.ChildViewControllers[1];
    }
