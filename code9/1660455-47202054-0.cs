    public static SportsFacility SelectedFacility
    {
        get
        {
            return (Session["SelectedFacility"] as SportsFacility);
        }
        set
        {
            Session["SelectedFacility"] = value;
        }
    }
