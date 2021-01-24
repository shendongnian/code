    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.RouteData.Values["id"] != null)
        {
            int eventID;
            if (int.TryParse(Page.RouteData.Values["id"], out eventID))
            {
               //render event based on numeric ID
            }
            else
            {
               //lookup event based on a string title. Then you could use a url like:
               //https://example.com/Awesome-Event/SuperbowlLII
            }
        }
    }
