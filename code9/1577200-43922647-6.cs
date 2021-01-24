    try
    {
        id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value); //This is the line with the error
        textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
        textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
        textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
        textBox4.Text = dataGridView1.SelectedCells[4].Value.ToString();
    }
    catch(InvalidCastException exception)
    {
        // not much to do with it, you can display assign empty valuest to your text boxes or notify user that there's nothing to select
    }
    
