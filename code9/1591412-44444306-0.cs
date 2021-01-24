    protected void Button2_Click(object sender, EventArgs e)
    {
    	ArrayList FullNameApplicantArray2 = new ArrayList();
    	FullNameApplicantArray2 = Session["ListOfApplicants"];
    	FullNameApplicantArray2.Add("(" + TextBox1.Text + ")");
    	Session["ListOfApplicants"] = FullNameApplicantArray2;
    
    	foreach (var item in Session["ListOfApplicants"].ToString())
    	{
    		Debug.Write(item);
    	}
    	Debug.WriteLine("");
    }
