    public class MyLabel : Label
    {
        new public string Text { get { return base.Text; } }
        new public string BackColor { get { return base.BackColor; } }
        public MyLabel()
        {
            base.Text = "This text is fixed";
            base.BackColor= Color.Green;
        }
    }
