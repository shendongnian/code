    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                //in this case I will show the form in my secondary screen.
                var screen = Screen.AllScreens.Last(); 
                this.Bounds = screen.Bounds;
            }
        }
    }
