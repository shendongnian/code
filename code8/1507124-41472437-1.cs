    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            b3.Click += new EventHandler(Popup);
        }
        private void Typhok(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x.Equals(sender))
                    x.ForeColor = Color.Magenta;
                else
                    x.ForeColor = Color.Black;
            }
        }
        private void Popup(object sender, EventArgs e)
        {
           MessageBox.Show("hello!");
        }
    }
