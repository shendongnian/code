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
