     string conString = "xxxxxxxx";
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            foreach (DataGridViewRow row in dataGridViewStock.Rows)
            {
                SqlCommand insert = new SqlCommand();
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    insert.Parameters.AddWithValue("@size", row.Cells[0].Value);
                    insert.Parameters.AddWithValue("@quantity", row.Cells[1].Value);
                    insert.Parameters.AddWithValue("@codeArticleComponent", labelComponentChosen.Text);
                }
                insert = ("INSERT INTO stock_test(size,quantity,codeArticleComponent) VALUES (@size,@quantity,@codeArticleComponent)", con);
                insert.ExecuteNonQuery();
                insert.Parameters.Clear();
            }
