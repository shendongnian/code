    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            MyColors.firstColor = Color.Blue;
            MyColors.secondColor = Color.Yellow;
            // add events to all requested controls
            AddEvent(new Control[] {
            label1,
            label2,
            label3,
        });
    
        }
    
        public void AddEvent(Control[] myControls)
        {
            foreach (Control c in myControls)
            {
                c.MouseClick += Control_Click;
            }
        }
    
        private void Control_Click(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = MyColors.GetColor(((Control)sender).BackColor);
        }
    }
    
    static class MyColors
    {
        public static Color firstColor { get; set; } = Color.Black;
        public static Color secondColor { get; set; } = Color.White;
    
        public static Color GetColor(Color color)
        {
            if (color == firstColor)
            {
                return secondColor;
            }
            else
            {
                return firstColor;
            }
        }
    }
