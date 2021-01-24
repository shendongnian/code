    public partial class Button : UserControl
    {
        public Button()
        {
            // note that you can use designer to set button1 look and subscribe to events
            InitializeComponent(); 
            button1.BackColor = Color.FromArgb(0, 135, 190);
            button1.ForeColor = Color.Black;
        }
        // don't forget to subscribe button event to this handler
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e); // raise control's event
        }
        // ...
    }
