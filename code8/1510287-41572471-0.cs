    int getal = 0;
    for (int i = 0; i < 3; i++)
    {
        getal++;
        DataGridViewCell  c = dgvOverzicht.Rows[getal - 1].Cells[i];
        if (c.Value != null)
        {
            listBox1.Items.Add(c.Value.ToString());
        }
    }
