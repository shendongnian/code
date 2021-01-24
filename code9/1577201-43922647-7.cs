    if(string.IsNullOrWhiteSpace(dataGridView1.SelectedCells[0].Value))
    {
        return;
    }
    id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value); 
    //Assign values to textboxes
