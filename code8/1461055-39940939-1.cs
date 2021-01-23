    public DgvColumnHeaderMerge()
    {
       InitializeComponent();
    }
    
    private void DgvColumnHeaderMerge_Load (object sender, EventArgs e)
    {
       this.dataGridView1.Columns.Add("JanWin", "Win");
       this.dataGridView1.Columns.Add("JanLoss", "Loss");
       this.dataGridView1.Columns.Add("FebWin", "Win");
       this.dataGridView1.Columns.Add("FebLoss", "Loss");
       this.dataGridView1.Columns.Add("MarWin", "Win");
       this.dataGridView1.Columns.Add("MarLoss", "Loss");
                   
       for (int j = 0; j < this.dataGridView1.ColumnCount; j++)
       {
         this.dataGridView1.Columns[j].Width = 45;
       }
    
       this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
       this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;
       this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment .BottomCenter;
    }
