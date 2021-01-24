    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
    public class Form1 : Form
    {
        private Form2 Form2;
        public Form1()
        {
            InitializeComponent();
            this.Form2 = new Form2();
        }
        private void pictureBox1_OnClick(object sender, EventArgs e)
        {
            int DummyID = 4;
            this.Form2.UpdateLabel(DummyID);
        }
    }
    public class Form2 : Form
    {
        public Form2()
        {
        }
        internal void UpdateLabel(int ID)
        {
            label1.Text = $"Picture ID {ID} Was Clicked!";
        }
    }
