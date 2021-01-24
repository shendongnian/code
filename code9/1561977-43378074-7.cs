    //This is the load event handler for the second page
    public void Page_Load()
    {
        this.SomeProperty = Session["Temp"];
        Session.Remove("Temp");
    }
