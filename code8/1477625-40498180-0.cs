    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            //Your init code goes here...
            clStartDate.SelectedDate = StartInputDate;
            clStartDate.VisibleDate = StartInputDate;
            clMaintEndDate.SelectedDate = StartInputDate.AddYears(1);
            clMaintEndDate.VisibleDate = StartInputDate.AddYears(1);
        }
        //Other code which should run for every page_load goes here...
    }
