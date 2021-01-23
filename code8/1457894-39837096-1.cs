    string tempValue = "";
    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempValue = dataGridView1.CurrentCell.Value.ToString(); // every edit start took the value and put it to tempValue.
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (tempValue != dataGridView1.CurrentCell.Value.ToString()) // we need to compare tempValue and currentValue. If we don't, even we don't do any changes it will show dialog result.
            {   // take the current value (changed value)
                string currentValue = dataGridView1.CurrentCell.Value.ToString(); 
                DialogResult dialogResult = MessageBox.Show("old value:" + tempValue + " new value:" + currentValue, "Confirm Change", MessageBoxButtons.YesNo); //show dialog result
                if (dialogResult == DialogResult.Yes) // if yes do something
                {
                    // yes
                }
                else if (dialogResult == DialogResult.No) // if no cancel changed value set old value which is tempValue.
                {
                    dataGridView1.CurrentCell.Value = tempValue;
                }
            }
           
        }
