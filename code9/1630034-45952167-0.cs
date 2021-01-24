    public partial class CustomTrackBar : Panel
    {
        private Panel backdrop;
        private Panel minBar;
        private Panel maxBar;
        private Panel currentBar;
        private Label minDisplay;
        private Label maxDisplay;
        private Label currentDisplay;
        public CustomTrackBar()
        {
            InitializeComponent(); // This should almost always be first.
            backdrop = new Panel() {
                BackColor = Color.LightGreen,
                // set position, size, etc.
            };
            // add event handlers to backdrop...
            Controls.Add(backdrop);
            // repeat for minBar, maxBar, etc.
            SizeChanged += (sender, args) => {
                Update();
            };
            // ... remaining initialization logic.
        }
        private void Update()
        {
            // adjust the position and size of each inner control...
        }
    }
