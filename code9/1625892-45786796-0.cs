    private Random rnd = new Random(1000);
    private void button1_Click(object sender, EventArgs e)
        {
        const Int32 xDelta = 5; // the horizontal distance between the added Buttons
        Int32 y = button1.Location.Y + 5 + button1.Height;
        Int32 x = button1.Location.X;
        Point loc = new Point(x, y);
        this.SuspendLayout(); // this is Form that is the Parent container of the Buttons
        for (Int32 i = 1; i <= 10; i++)
            {
            Button btn = new Button { Parent = this, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink };
            btn.Text = new string('A', rnd.Next(1, 21));
            btn.Location = loc;
            Size sz = btn.GetPreferredSize(Size.Empty); // the size of btn based on Font and Text
            loc.Offset(sz.Width + xDelta, 0);
            }
        this.ResumeLayout(true);
        }
