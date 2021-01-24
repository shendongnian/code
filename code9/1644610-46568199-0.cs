    Panel panel = new Panel();
            panel.BackColor = Color.White;
            panel.Size = new Size(200, 200);
            
            Label lb = new Label() { Text = "Hello" };
            panel.Padding = new Padding(10);
            lb.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(lb);
            
            this.Controls.Add(panel);
