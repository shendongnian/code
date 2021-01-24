    SqlConnection con=new SqlConnection("connection string");
    SqlCommand cmd=new SqlConnection(SqlQuery,Con);
    Con.Open();
    SqlDataReader dr=new SqlDataReadr();
    dr=cmd.Executereader();
    if(dr.read())
    {
        TextBox1.Text=dr.GetValue(0).Tostring();
    }
    Con.Close();
