    using(SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Form;Integrated Security=True";))
    {          
        
        con.Open();
        SqlCommand com = new SqlCommand("select * from Form", con);
        using(SqlDataAdapter sda = new SqlDataAdapter(com));
        {
            DataTable resultTbl = new DataTable();
            sda.Fill(resultTbl);
            dataGridView1.DataSource = resultTbl;
        }
    }
