    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
           loadList();
           emailT.Text = Request.QueryString["mail"];
        }
    }
    protected void SendMail(object sender, EventArgs e)
    {
        BO.Messages mail = new BO.Messages();
        if(emailT.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Please fill in an email')", true);
            }
            else
            {
                mail.TemplateEmail(emailT.Text, title.Text, txtDetails.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", "alert('Email sent!'); window.close()", true);
            }
        }
