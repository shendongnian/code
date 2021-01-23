     <script language="c#" runat="server">
                protected void Page_Load(object sender, EventArgs e)
                {
                    DateTime date = DateTime.Now;
                    dateToday.Text = " " + date.ToString("d");
                    DayOfWeek day = DateTime.Now.DayOfWeek;
                    dayToday.Text = " " + day.ToString();
        
                    if ((dayToday.Text == DayOfWeek.Saturday.ToString()) || (dayToday.Text == DayOfWeek.Sunday.ToString()))
                    {
                        Response.Write("This is a weekend");
                    }
                }
            </script>
