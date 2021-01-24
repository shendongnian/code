    private void checkabst_Click(object sender, EventArgs e)
        {
            string[] present1 = new string[listbox_present.Items.Count];
            List<string> present = new List<string> { ""};
            List<string> absent = new List<string>();
            List<string> total = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select Rfid_Uid From Studetails", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    total.Add(sdr[0].ToString());
                }
            }
           present = listbox_present.Items.Cast<string>().ToList();
           absent = total.Except(present).ToArray();
           foreach (var stud in absent)
           {
               MessageBox.Show(stud);
           }
        }
