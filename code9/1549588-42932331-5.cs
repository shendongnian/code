    public partial class Form1 : Form
    {
        public Form1()
        {
            //Simulate a long init
            Thread.Sleep(2000);
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            foreach (var splashScreen in Application.OpenForms.OfType<Form2>())
            {
                splashScreen.BeginInvoke( (Action) delegate () { splashScreen.Close(); });
            }
        }
    }
