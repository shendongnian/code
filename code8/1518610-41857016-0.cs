    protected void Page_Load(object sender, EventArgs e){}
    protected void btnFirst_Click(object sender, EventArgs e)
    {
       List<string> ErrorList = new List<string>();
       for (int i = 0; i < 5; i++)
       {
            ErrorList.Add(i);      
       }
       Session["Errors"] = ErrorList;
       txtResult.Text = "Length of list: " + ErrorList.Count;
     }
    protected void btnSecond_Click(object sender, EventArgs e)
    {
       List<string> ErrorList = (List<string>)Session["Errors"];
       txtResult.Text = "Length of list: " + ErrorList.Count; 
    }
