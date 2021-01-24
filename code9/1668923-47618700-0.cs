    public partial class Form1 : Form
    {
        MyDataTable dt;
        BindingSource bs;
    
        public Form1()
        {
            InitializeComponent();
    
            dt = new MyDataTable();
            bs = new BindingSource();
            bs.DataSource = dt.DefaultView;
            dataGridView1.DataSource = bs;
        }
    
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var r = new Random();
            var dr = dt.NewRow();
            dr[0] = r.Next(1111, 9999);
            dr[1] = r.Next(1111, 9999);
            dr[2] = r.Next(1111, 9999);
            dt.Rows.InsertAt(dr, 0);
        }
    
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            dt.Rows.RemoveAt(0);
        }
    
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text =
            textBox2.Text =
            textBox3.Text = string.Empty;
            UpdateDgv();
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
    
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateDgv();
        }
    
        private void UpdateDgv()
        {
            string filter = GetFilter();
    
            if (filter != string.Empty)
                this.Text = filter;
            else this.Text = "All records";
    
            bs.Filter = filter;
        }
    
        private string GetFilter()
        {
            string filter = string.Empty;
    
            if (textBox1.Text != string.Empty)
                filter = string.Format("Data1 like '{0}%'", textBox1.Text);
    
            if (textBox2.Text != string.Empty)
            {
                if (textBox1.Text != string.Empty)
                    filter += " and ";
                filter += string.Format("Data2 like '{0}%'", textBox2.Text);
            }
    
            if (textBox3.Text != string.Empty)
            {
                if (filter != string.Empty)
                    filter += " and ";
                filter += string.Format("Data3 like '{0}%'", textBox3.Text);
            }
    
            return filter;
        }
    }
