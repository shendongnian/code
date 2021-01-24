        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection("Data Source=***; Initial Catalog=Chinook; User ID=sa; Password=***"))
            using (var adapter = new SqlDataAdapter("SELECT * FROM Artist", con))
            using (new SqlCommandBuilder(adapter))
            {
                adapter.Fill(table);
                con.Open();
                adapter.Update(table);
            }
        }
