    public Page1 ()
	{
		InitializeComponent ();
        var d = new Detail {
            BusinessName = "Name",
            PostCode = "123"
        };
        BindingContext = d;
        test.Text = d.PostCode;
    }
