        public partial class dload : Form
    {
        public dload()
        {
            InitializeComponent();
        }
    private void dload_Load(object sender, EventArgs e)
    {
        label1.Visible = false;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 5000;
        for (i = 0; i <= 5000; i++)
        {
            progressBar1.Value = i;
            progressBar1.Refresh()
            if (i == 5000)
            {
                label1.Visible = true;
            }
        }
    }
    }
