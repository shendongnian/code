    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        
        }
        private void Search_Click(object sender, EventArgs e)//When user clicks on search button
        {
            SearchEngineForm1 frm2 = new SearchEngineForm1();
            frm2.searchAddress = "https://www.google.com/search?q=" + txtSearch.Text.Replace(" ", "+");
            frm2.Show();
        }
    }
