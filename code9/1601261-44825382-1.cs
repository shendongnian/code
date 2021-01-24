    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.C)
        {
            Console.WriteLine("Copying: " + (dataGridView1.SelectedCells[0].Value as Item).Name);
        }
    }
