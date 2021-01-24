    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList FullNameApplicantArray = (ArrayList)Session["FullNameApplicantArray"] ?? new ArrayList();
        FullNameApplicantArray.Add("(" + TextBox1.Text + ")");
        foreach (var item in FullNameApplicantArray)
        {
            Debug.Write(item);
        }
        Debug.WriteLine("");
        Session["FullNameApplicantArray"] = FullNameApplicantArray;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/WebForm2.aspx");
    }
