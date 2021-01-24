    switch (DropDownList1.SelectedValue)
            {
                case "blue":
                    Button1.BackColor = System.Drawing.Color.Blue;
                    break;
                case "green":
                    Button1.BackColor = System.Drawing.Color.Green;
                    break;
                case "red":
                    Button1.BackColor = System.Drawing.Color.Red;
                    break;
                case "yellow":
                    Button1.BackColor = System.Drawing.Color.Yellow;
                    break;
                case "white":
                    Button1.BackColor = System.Drawing.Color.White;
                    break;
                case "black":
                    Button1.BackColor = System.Drawing.Color.Black;
                    break;
                default:
                    Button1.BackColor = System.Drawing.Color.Gray;
                    break;
            }
