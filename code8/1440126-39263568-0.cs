    static string previousValue = "";
    protected void Page_Load()
    {
      if(!IsPostBack)
      {
           previousValue = "5";
      }
    }
    protected void txtMorningMinutes_TextChanged(object sender, EventArgs e)
    {
     if(Convert.ToInt32(txtMorningMinutes.Text) > Convert.ToInt32(txtCapacityMinutes.Text))
    {
     txtMorningMinutes.Text = Convert.ToInt32(txtMorningMinutes.Text) - Convert.ToInt32(txtCapacityMinutes.Text)
    }
    }
