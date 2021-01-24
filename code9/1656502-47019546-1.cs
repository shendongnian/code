    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private string rootDirectory = @"D:\test\Blocks";
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Directory.GetDirectories(rootDirectory)
                .Select(Path.GetFileName).ToList();
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parentDir = Path.Combine(rootDirectory, listBox1.SelectedItem.ToString());
            listBox2.DataSource = Directory.GetDirectories(parentDir)
                .Select(Path.GetFileName).ToList();
        }
        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parentDir = Path.Combine(rootDirectory, listBox1.SelectedItem.ToString(), 
                listBox2.SelectedItem.ToString());
            dataGridView1.DataSource = Directory.GetFiles(parentDir)
                .Select(f => new { FileName = Path.GetFileName(f) }).ToList();
        }
    }
