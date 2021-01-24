    protected void GridView_DataBound(object sender, EventArgs e)
    {
        SessionWrapper.GetInstance().RemoveSessionItem("OriginalData");
        SessionWrapper.GetInstance().SetSessionItem("OriginalData", someData);
    }
