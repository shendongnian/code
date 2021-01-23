    delegate void FileSelected(string value);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //add the delegates to the usercontrol
        FileSelected fileSelected1 = new FileSelected(UserControl1_FileSelected);
        FileUploader1.FileSelected = fileSelected1;
    
        FileSelected fileSelected2 = new FileSelected(UserControl2_FileSelected);
        FileUploader2.FileSelected = fileSelected2;
    }
    
    private void UserControl1_FileSelected(string value)
    {
        Label1.Text += "1: " + value + "<br>";
    }
    
    private void UserControl2_FileSelected(string value)
    {
        Label1.Text += "2: " + value + "<br>";
    }
