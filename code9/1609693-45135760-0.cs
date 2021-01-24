    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("firstColumn", "Name");
            dataGridView1.Columns.Add("secondColumn", "Mark");
            dataGridView1.Rows.Add(99);
            for (int i = 99; i >= 0; i--)
            {
                dataGridView1[0, i].Value = "column1 value " + (100 - i);
                dataGridView1[1, i].Value = "column2 value " + (100 - i);
            }
            
            dataGridView1.FirstDisplayedScrollingRowIndex = 0;
        }
    }
