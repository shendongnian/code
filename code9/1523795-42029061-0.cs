    public partial class YourForm : Form
    {
        public YourForm()
        {
            InitializeComponent();
            
            KeyDown += KeyDownHandler; // subscribe to event
            KeyPreview = true; // set to true so key events of child controls are caught too
        }
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Insert) return;
            btn1.Left = btn1.Left + 1;// btn is a button
            e.Handled = true; // indicate that the key was handled by you
            //Update(); // this is not necessary, after this method is finished, the UI will be updated
        }
    }
