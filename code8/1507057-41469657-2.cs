    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 oForm = new Form2();
            oForm.ChangeLabelText += ChangeLabelText;
            oForm.Show();
        }
        private void ChangeLabelText(object sender, EventArgs e)
        {
            string sText = sender as string;
            label1.Text = sText;
        }
