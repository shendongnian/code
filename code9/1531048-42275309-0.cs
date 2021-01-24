      private void Form1_Load(object sender, EventArgs e)
            {
                Label Label = new Label();
                Label.Location = new System.Drawing.Point(50, 50);
                Label.Width = 50;
                Label.Height = 50;
                Label.Name = "lblTest";
                this.Controls.Add(Label);
                Label.Text = "test";
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                var lbl = this.Controls.Find("lblTest",true); // find label with name
                foreach (var item in lbl) 
               // there can be multiple lblTest with same name so I used foreach (this is optional btw you can remove it)
                {
                    Label tempLabel = item as Label;
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                    System.Drawing.Pen myPen = new Pen(myBrush, 2);
                    e.Graphics.DrawEllipse(myPen, new System.Drawing.Rectangle(tempLabel.Location.X - (tempLabel.Width / 2),
                        tempLabel.Location.Y - (tempLabel.Height / 2)  , tempLabel.Width + 40, tempLabel.Height + 40));
                }
            }
