        bool j = false;
        foreach (DataGridViewRow rows in dataGridView1.Rows)
        {
            for (int i = 1; i < rows.Cells.Count; i++)
            {
                if (textBox3.Text == rows.Cells[i].Value.ToString())
                {
                    j = true;
                    break; // No need to continue after finding the result
                }
            }
        }
        if (j) // j is already a boolean
        {
            MessageBox.Show("It exists!");
        }
        else
        {
            MessageBox.Show("It doesn't exist!!");
        }
