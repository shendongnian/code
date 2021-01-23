    protected void Page_Load(object sender, EventArgs e)
    {   
        if(!IsPostBack) {
        TextBox1.Text = "Hello";               
        }
    }
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {
       TextBox1.Text = "Good Bye";
    }
