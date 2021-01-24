    class YourClass
    {
        private DataTable dt { get; set; }
        private int CurrentRow { get; set; }
        private void SomeMethod()
        {
            OleDbDataAdapter dAdap = new OleDbDataAdapter(command);
            dt = new DataTable();
            dAdap.Fill(dt);
            CurrentRow = 0;
            AssignToRow();
        }
    
        private void AssignToRow()
        {
            var row = dt.Rows[CurrentRow];
            lblQuest.Text = row["QUESTION"].ToString();
            btnA.Text = row["C1"].ToString();
            btnB.Text = row["C2"].ToString();
            btnC.Text = row["C3"].ToString();
            btnD.Text = row["C4"].ToString();
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            CurrentRow++;
            AssignToRow();
        }
    }
