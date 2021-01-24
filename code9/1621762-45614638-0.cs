    protected void Page_Init(object sender, EventArgs e)
    {
        CreateDynamicControls();
    }
    
    private void CreateDynamicControls()
    {
        for (int i = 0; i < 5; i++)
        {
            TextBox txt = new TextBox();
            txt.ID = "txt" + i;
            PlaceHolder1.Controls.Add(txt);
        }
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        IList<string> data = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            string txtID = "txt" + i;
            TextBox txt = (TextBox)PlaceHolder1.FindControl(txtID);
            data.Add(txt.Text);
        }
    }
