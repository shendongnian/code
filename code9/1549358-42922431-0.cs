     protected void Page_Load(object sender, EventArgs e)
     {
       if (Page.IsPostBack == false)
       {
          dtAlgebraLoad = DateTime.Now;
          lblTime.Text = dtAlgebraLoad.ToString();
       }
     }
