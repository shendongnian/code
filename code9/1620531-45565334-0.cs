    protected void savesubmit_Click(object sender, EventArgs e)
    {
    
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Khayati;Integrated Security=True");
        string qu = string.Format("insert into Ordertb (nokar,modeledokht,tozihat,username) values('{0}','{1}',N'{2}', '{3}')", DropDownList1.Text, DropDownList2.Text, tozihtxt.Text, Convert.ToString(Session["username1"]));
        SqlDataAdapter da = new SqlDataAdapter(qu, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "ordertbl");
    
    }
