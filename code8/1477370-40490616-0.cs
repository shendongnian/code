    public override void LoadView()
    {
        base.LoadView();
    	_imnLogo = new UIImageView(UIImage.FromFile("imn_logo.png"));
    	_imnLogo.Frame = View.Frame;
    	_imnLogo.ContentMode = UIViewContentMode.ScaleAspectFill;
    	View.AddSubview(imageView);
        View.SendSubviewToBack(imnLogo); // Do this if you want to place other `View`s on top of the logo...
    }
