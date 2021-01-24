    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
    btn.HeaderText = "Button";
    btn.Text = "Click Me!";
    btn.Name = "btn";
    dataGridView1.Columns.Add(btn);
    btn.UseColumnTextForButtonValue = true;
