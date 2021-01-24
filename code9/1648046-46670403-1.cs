    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
        this.dataGridView1.CellPainting += dataGridView1_CellPainting;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("Column1", typeof(bool));
        dt.Rows.Add(false);
        dt.Rows.Add(true);
        this.dataGridView1.DataSource = dt;
    }
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            var value = (bool?)e.FormattedValue;
            e.Paint(e.CellBounds, DataGridViewPaintParts.All &
                                    ~DataGridViewPaintParts.ContentForeground);
            var img = value.HasValue && value.Value ?
                Properties.Resources.Checked : Properties.Resources.UnChecked;
            var size = img.Size;
            var location = new Point((e.CellBounds.Width - size.Width) / 2,
                                        (e.CellBounds.Height - size.Height) / 2);
            location.Offset(e.CellBounds.Location);
            e.Graphics.DrawImage(img, location);
            e.Handled = true;
        }
    }
