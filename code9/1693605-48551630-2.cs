            foreach (Control control in Controls)
            {
                control.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                switch (control)
                {
                    case TextBox tbx:
                        tbx.ForeColor = Color.SlateGray;
                        tbx.BackColor = Color.White;
                        break;
                    case Label lbl:
                        lbl.ForeColor = Color.SteelBlue;
                        lbl.BackColor = Color.White;
                        break;
                    case Button btn:
                        btn.ForeColor = Color.White;
                        btn.BackColor = Color.SteelBlue;
                        btn.FlatStyle = FlatStyle.Flat;
                        break;
                }
            }
