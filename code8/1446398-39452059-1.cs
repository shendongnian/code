    private void cbxBaseDados_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbxBaseDados.Text.Equals("Value")) {
            dtInical.Show();
            dtFinal.Show();
            lbPeriodo.Hide();
            periodoTimePicker1.Hide();
            periodoTimePicker2.Hide();
            txtPeriodo1.Hide();
            txtPeriodo2.Hide();
            tableLayoutPanel2.ColumnCount = 13;
            tableLayoutPanel2.Controls.Add(dtInical, 6, 0);
            tableLayoutPanel2.Controls.Add(lbAPeriodo, 7, 0);
            tableLayoutPanel2.Controls.Add(dtFinal, 8, 0);
        } else {
            dtInical.Hide();
            dtFinal.Hide();
        }
    }
