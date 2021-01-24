    protected void Button1_Click(object sender, EventArgs e)
    {
    	FullNameApplicantArray.Add("(" + TextBox1.Text +")");
    	Session["ListOfApplicants"] = FullNameApplicantArray;
    
    	foreach (var item in Session["ListOfApplicants"].ToString())
    	{
    		Debug.Write(item);
    	}
    	Debug.WriteLine("");
    }
        
