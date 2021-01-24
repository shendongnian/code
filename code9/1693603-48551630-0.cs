            foreach (Control control in CallingForm.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tbx = control as TextBox;
                    tbx.ForeColor = Color.SlateGray;
                    tbx.BackColor = Color.White;
                    tbx.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                }
                if (control is Label)
                {
                    Label lbl = control as Label;
                    lbl.ForeColor = Color.SteelBlue;
                    lbl.BackColor = Color.White;
                    lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                }
                if (control is Button)
                {
                    Button btn = control as Button;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.SteelBlue;
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }
