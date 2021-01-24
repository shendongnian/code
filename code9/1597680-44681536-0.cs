    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindEntree();
                }
                else
                {
                    Label1.Text = TextBox1.Text;
                }
    
            }
