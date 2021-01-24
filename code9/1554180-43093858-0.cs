    OpenFileDialog openfiledialog = new OpenFileDialog();
    
    protected void Page_Load(object sender, EventArgs e)
    {    
             if (!IsPostBack)
             {
                openfiledialog.FileName = "test.nhc";
             }
    }
    
    private void buttonSave_Click(object sender, EventArgs e) 
    {
              openfiledialog.ShowDialog();
    }
