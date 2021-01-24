    for(int i = 0; i < 101; i++)
            {
                Label lbl = new Label();
                lbl.Name = "lbl" + i.ToString();
                lbl.Text = i.ToString();
                lbl.Location = new System.Drawing.Point(15 + j, 156);
                lbl.Size = new System.Drawing.Size(65, 15);
                this.Controls.Add(lbl);
                j += 20;
            }
