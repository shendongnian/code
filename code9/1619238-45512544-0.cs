    public partial class Form1 : Form
    {
        private Dictionary<Control, int> heights = new Dictionary<Control, int>();
        public Form1()
        {
            InitializeComponent();
            foreach (Control control in Controls)
            {
                heights.Add(control, control.Height);
            }
        }
        private void button1_Resize(object sender, System.EventArgs e)
        {
            var control = (Control) sender;
            var oldHeight = heights[control];
            if (control.Height != oldHeight)
            {
                heights[control] = control.Height;
                // handle your resize
            }
        }
    }
