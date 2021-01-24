        protected void btnSend_Click(object sender, EventArgs e)
        {
            Session["SomeDate"] = Convert.ToDateTime(lblSelectedDate.Text).AddDays(1);
             Response.Redirect("WebForm2.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var dateText = Convert.ToDateTime(Session["SomeDate"]);
        }
