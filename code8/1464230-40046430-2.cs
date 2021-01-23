	public string TestProperty
	{
		get
		{
			//return txtMyTest.Text;
			return Request.Form["ctl00$FeaturedContent$txtMyTest"];
		}
		set
		{
			txtMyTest.Text = value;
		}
	}
	protected void Page_Load(object sender, EventArgs e)
	{
		if (IsPostBack)
		{
			lblMyTest.Text = TestProperty;
		}
	}
