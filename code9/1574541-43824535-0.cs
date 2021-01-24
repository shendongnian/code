    if(Connection.Username!=null){
     SqlDataAdapter sda = new SqlDataAdapter("select UserName from CustomerTrans  where UserName='"+Connection.Username+"'" , con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                }
    }
