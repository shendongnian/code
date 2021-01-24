    public partial class Form1 : Form
    {
    	string log = "";
        List<Color> changedBackColors = new List<Color>();
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.CellStyleContentChanged +=
                dataGridView1_CellStyleContentChanged;
            this.dataGridView1.CellFormatting +=
                dataGridView1_CellFormatting;
            this.Shown += Form1_Shown;
        }
        void Form1_Shown(object sender, EventArgs e)
        {
            log += "Change Cell[0,0] (color = blue)\r\n";
            this.dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.Blue;
            log += "Change Cell[0,1] (color = red)\r\n";
            this.dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.Red;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Add("column1", "column1");
            this.dataGridView1.Columns.Add("column1", "column1");
            this.dataGridView1.Rows.Add("cell1", "cell2");
        }
        private void dataGridView1_CellStyleContentChanged(
            object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {
            log += string.Format(
                "CellStyleContentChanged occurs for Cell[?,?] (color = {0})\r\n",
                e.CellStyle.BackColor.Name);
            this.changedBackColors.Add(e.CellStyle.BackColor);
        }
        private void dataGridView1_CellFormatting(
            object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.changedBackColors.Count > 0)
            {
                if (this.changedBackColors.Contains(e.CellStyle.BackColor))
                {
                    log += string.Format(
                        "CellFormatting occurs for Cell[{0},{1}] (color = {2})\r\n",
                         e.RowIndex, e.ColumnIndex, e.CellStyle.BackColor.Name);
                    this.changedBackColors.Remove(e.CellStyle.BackColor);
                    
                    // TODO: change excel file
                    // ...
                }
            }
        }
    }
