        void Fill_ListBox()
        {
            using (SqlConnection con = new SqlConnection(@"........."))
            {
                con.Open();
                using (SqlDataAdapter a = new SqlDataAdapter("Select * From DocStorage", con))
                {
                    var t = new DataTable();
                    a.Fill(t);
                    listBox1.DisplayMember = "DocumentName";
                    listBox1.ValueMember = "";
                    listBox1.DataSource = t;
                }
            }
        }
