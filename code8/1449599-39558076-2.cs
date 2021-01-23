    bool isLoading = true;
    protected void Page_Load(object sender, EventArgs e)
        {
            //if(isPostBack){
                isLoading = true;
                //do your other form loading stuff
                isLoading=false;
           // }
        }
     protected void ASPxDateEdit1_CalendarDayCellPrepared(object sender, CalendarDayCellPreparedEventArgs e)
    {
        if(!isLoading)
        {
            isLoading = true;
            int Date;
            bool isValidDate = int.TryParse(e.Date.Day.ToString(), out Date);
            if (isValidDate)
            {
                if (Date > 0 && Date < 10)
                {
                    e.Cell.Text = "0" + e.Date.Day.ToString();
                }
            }
            isLoading = false;
        }
    }
