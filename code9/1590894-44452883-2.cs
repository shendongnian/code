        private void button1_Click(object sender, EventArgs e)
        {          
           conDB.InsertEntrie(txtidno.Text, DatePicker.Text, TimePicker.Text, 
           cmbtype.Text, txtremarks.Text);
           txtvalue = Convert.ToString(conDB.Entries() - 1);
        }
