    Panel p1 = new Panel();
    p1.Size = new Size(0, 0);
    p1.AutoSize = true;
    Button b1 = new Button();
    b1.AutoSize = true;
    b1.Text = "Some text";
    Button b2 = new Button();
    b2.AutoSize = true;
    b2.Text = "Some other text";
    p1.Controls.Add(b1);
    p1.Controls.Add(b2);
    b2.Location = new Point(b1.Left, b1.Top+b1.Height);
    this.Controls.Add(p1);
    p1.Location = new Point((ClientSize.Width - p1.Width) / 2,
                           (ClientSize.Height - p1.Height) / 2);
