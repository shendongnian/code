    protected void Page_Load(object sender, EventArgs e)
    {
        var testData = Enumerable.Range(1, 10).Select(i => new { someText = "Button " + i.ToString() }).ToList();
        RepeaterTest.DataSource = testData;
        RepeaterTest.DataBind();
    }
    protected void RepeaterTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        dynamic foo = e.Item.DataItem;
        ((Button)e.Item.FindControl("TestButton")).CssClass = foo.someText;
    }
