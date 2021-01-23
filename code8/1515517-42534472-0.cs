     public void DrawingPanel2_MouseMove(object sender, MouseEventArgs e) 
        {
                if (e.X >= 100 && e.X <= 150 && e.Y >= 100 && e.Y <= 150)
                    {
                        toolStripStatusLabel1.Text = "Point A";
                        Label lblA = new Label();
                        lblA.Text = "Point A";
                        lblA.Location = new System.Drawing.Point(e.X, e.Y);
                        lblA.AutoSize = true;
                        DrawingPanel2.Controls.Add(lblA);
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = e.X + "," + e.Y;
                        DrawingPanel2.Controls.Clear();
                    }
            }
