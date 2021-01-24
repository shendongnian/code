     private void Form1_Load(object sender, EventArgs e)
        {
            Button testbutton = new Button();
            testbutton.Text = "button1";
            testbutton.Location = new Point(70, 70);
            testbutton.Size = new Size(100, 100);
            testbutton.Visible = true;
            testbutton.BringToFront();
            this.Controls.Add(testbutton);
        }
