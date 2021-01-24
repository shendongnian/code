    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //do not add dynamic controls here
        }
        //create a new ImageButton instance on every page load
        ImageButton ib = new ImageButton();
        //set some properties
        ib.CssClass = "mySlides";
        ib.ImageUrl = "~/myImage.png";
        //add the click method
        ib.Click += LinkButton_Click;
        //add the button to an existing control
        PlaceHolder1.Controls.Add(ib);
    }
