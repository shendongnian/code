    //Populate the DropDownList
    protected void DropDownList1_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
            // Instantiate your DropDownList
            DropDownList drpList = (DropDownList)sender;
            List<string> dateList = new List<string>();
            DateTime dt = DateTime.Now;
            for (int i = 1; i <= 18; i++)
            {
                dt = dt.AddMonths(-1);
                var month = dt.ToString("MMMM");
                var year = dt.Year;
                dateList.Add(String.Format("{0}-{1}", month, year));
            }
            // Bind resulting list to the DropDownList
            drpList.DataSource = dateList;
            drpList.DataBind();
       }
    }
    //Get the Selected Value on change
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // assign the selected item value to a variable 
            string value = ((DropDownList)sender).SelectedValue;
        }
----------
   
