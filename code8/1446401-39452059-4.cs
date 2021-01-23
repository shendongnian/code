    DateTimePicker dtInical;
    DateTimePicker dtFinal;
    
    private void cbxBaseDados_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dtInical == null)
        {
            dtInical = new DateTimePicker() {
                 Name = "dateTimePickerLogInicial",
                 Size = new Size(135, 68),
                 Margin = new Padding(3, 9, 3, 3)
            };
            tableLayoutPanel2.Controls.Add(dtInical, 6, 0);
        }
        if (dtFinal == null)
        {
            dtFinal = new DateTimePicker() {
                Name = "dateTimePickerLogFinal",
                Size = new Size(135, 68),
                Margin = new Padding(3, 9, 3, 3)
            };
            tableLayoutPanel2.Controls.Add(dtFinal, 8, 0);
        }
        if (cbxBaseDados.Text.Equals("Value")) {
            lbPeriodo.Hide();
            periodoTimePicker1.Hide();
            periodoTimePicker2.Hide();
            txtPeriodo1.Hide();
            txtPeriodo2.Hide();
            tableLayoutPanel2.ColumnCount = 13;
            tableLayoutPanel2.Controls.Add(lbAPeriodo, 7, 0);
        } else {
            dtInical.Dispose();
            dtFinal.Dispose();
            dtInical = null;
            dtFinal = null;
         }
    }
