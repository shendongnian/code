    class Form2
    {
        delegate void PassDataDelegate(DataTable dt1);
        public event PassDataDelegate PassData;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("MessageID", typeof(string));
            dt1.Columns.Add("Name", typeof(string));
            dt1.Columns.Add("Number", typeof(string));
            DataRow dr = dt1.NewRow();
            dr["MessageID"] = IDtext.Text; ;
            dr["Name"] = nameText.Text;
            dr["Number"] = numberText.Text;
            dt1.Rows.Add(dr);
            // This is where you call your event
            PassData(dt1);
         }
    }
    class Form1
    {
        // Your existing Form1 class definition
        private static void YourMethodWhereYouLaunchForm2()
        {
            Form2 f2 = new Form2();
            // Add this handler and you will get it invoked whenever you ask from Form2
            f2.PassData += Handle_DataPassed;
        }
        private void Handle_DataPassed(DataTable dt1)
        {
            // This is where you post the data now to the grid.
            dataGridView2.DataSource = dt1;
        }
    }
