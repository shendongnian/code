    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the datasource for the first listbox
            listBox1.DataSource = Directory.GetDirectories(@"D:\test\Blocks").ToList();
            // Hook up the selected index changed event handlers for both listboxes
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When an item changes in the first listbox, update the second listbox datasource
            var parentDir = listBox1.SelectedItem.ToString();
            listBox2.DataSource = Directory.GetDirectories(parentDir).ToList();
        }
        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When an item changes in the second listbox, update the datagridview datasource
            var parentDir = listBox2.SelectedItem.ToString();
            dataGridView1.DataSource = Directory.GetFiles(parentDir)
                .Select(f => new { FileName = Path.GetFileName(f) }).ToList();
        }
    }
