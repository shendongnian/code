    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RecurringJob.AddOrUpdate(() => sendmail1(), "0 0 10 * * ?");
        }
    }
