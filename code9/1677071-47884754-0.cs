    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            for (int month = 1; month <= 12; month++)
            {
                string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
                ddlMonthNames.Items.Add(new ListItem(monthName, month.ToString().PadLeft(2, '0')));
            }
     
            for (int month = 1; month <= 12; month++)
            {
                ddlMonths.Items.Add(new ListItem(month.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0')));
            }
        }
    }
