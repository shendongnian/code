     for (int i = 1; i < 31; i++)
            {
                if (((NumericUpDown)this.Controls["nup" + i.ToString()]).Value > 0)
                {
                    dataGridView1.Rows.Add(((Label)this.Controls["lbl" + i]).Text, ((NumericUpDown)this.Controls["nup" + i]).Value.ToString());
                }
    }
