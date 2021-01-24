    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.trackBar1.ValueChanged += trackBar1_ValueChanged;
        }
        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.trackBar1, trackBar1.Value.ToString());
        }
    }
