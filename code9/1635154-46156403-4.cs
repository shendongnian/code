    private void CheckRowCount()
        {
            // The data grid view's default behavior is such that it creates an additional row up front.
            // e.g. when you add 1st row, it creates 2nd row automatically.
            // If you use Count < MaxRows, the user won't be able to add the 10th row.
            if (dataGridView1.Rows.Count <= MaxRows)
            {
                dataGridView1.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = false;
            }
        }
