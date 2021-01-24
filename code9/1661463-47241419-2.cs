    namespace WindowsFormsApplication11
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                menuStrip1.Renderer = new CustomColors();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
        }
        
        private class CustomColors : ToolStripProfessionalRenderer
        {
            public CustomColors() : base(new MyColors()) { }
        }
    
        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.GreenYellow; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DarkBlue; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }
        }
    }
