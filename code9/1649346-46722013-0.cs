            Button[] buttons = new Button[4];
            for (int j = 0; j < 4; j++)
            {
                Button b = new Button();
                b.Left = x;
                b.Top = y;
                b.Width = WIDTH;
                b.Height = HEIGHT;
                b.Name = counter.ToString();
                counter++;
                x += VGAP + HEIGHT;
                this.Controls.Add(b); 
                buttons[i] = b;
            }
            //....
            button[3].Visible = false;
