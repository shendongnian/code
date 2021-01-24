    private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //assuming the datagrid displays ID in the 1st cell, Cells[0]
               string name = row.Cells[1].Value.ToString();
               string phoneNum = row.Cells[2].Value.ToString();
            }
            textBox2.Text = name;
            textBox3.Text = phoneNum;
            updateButton.BringToFront();
            saveButton.SendToBack(); //optional
        }
