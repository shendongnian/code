    public class Model
    {
        public string Text { get; set; }
    }
    BindingList<Model> list = new BindingList<Model>();
    private void Form1_Load(object sender, EventArgs e)
    {
        var column1 = new DataGridViewTextBoxColumn();
        column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        column1.DataPropertyName = "Text";
        column1.DefaultCellStyle = new DataGridViewCellStyle();
        column1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        column1.HeaderText = "Text";
        column1.Name = "column1";
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dataGridView1.Columns.Add(column1);
        this.dataGridView1.DataSource = list;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        list.Add(new Model() { Text = textBox1.Text });
    }
