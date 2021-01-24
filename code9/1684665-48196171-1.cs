            int j = 5;
            for (int i = 0; i < 101; i++)
            {
                Label lbl = new Label
                {
                    Name = "lbl" + i.ToString(),
                    Text = "lbl " + i.ToString(),
                    Location = new Point(10, 10 + j),
                    Size = new Size(50, 20)
                };
                this.Controls.Add(lbl);
                j += 20;
            }
