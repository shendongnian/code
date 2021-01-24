    private string _date = "";
    private double _total = 0;
    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            PopulateCombos();
        }
        catch (Exception)
        {
        }
     }
    private void PopulateCombos()
    {
        try
        {
            PopulateEveryDay();
            PopulateDaySales();
        }
        catch (Exception)
        {
        }
    } 
    
    private void PopulateEveryDay()
    {
        dgvEvery.DataSource = null;
        DataTable dtEvery = new DataTable();
        dtEvery.Columns.Add("date", typeof(DateTime));
        dtEvery.Columns.Add("total", typeof(double));
        DataRow dr = null;
        for (int i = 0; i < 10; i++)
        {
            dr = dtEvery.NewRow();
            dr[0] = System.DateTime.Now.AddDays(-i).ToShortDateString();
            if (i == 0)
                dr[1] = 100 * 1;
            else
                dr[1] = 100 * i * 2;
            dtEvery.Rows.Add(dr);
        }
        dgvEvery.DataSource = dtEvery;
    }
    private void PopulateDaySales()
    {
        dgvDaySales.DataSource = null;
        DataTable dtEvery = new DataTable();
        dtEvery.Columns.Add("date", typeof(DateTime));
        dtEvery.Columns.Add("total", typeof(double));
        DataRow dr = null;
        for (int i = 0; i < 10; i++)
        {
            dr = dtEvery.NewRow();
            dr[0] = System.DateTime.Now.AddDays(-i).ToShortDateString();
            if (i == 0)
               dr[1] = 100 * 1;
            else
               dr[1] = 100 * i * 3;
            dtEvery.Rows.Add(dr);
        }
        dgvDaySales.DataSource = dtEvery;
    }
    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)dgvDaySales.DataSource;
            DataRow[] dr = dt.Select("date = '" + _date + "'");
            foreach (DataRow item in dr)
            {
                item["total"] = Convert.ToDouble(item["total"]) + _total;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void dgvEvery_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            _date = Convert.ToString(Convert.ToDateTime(dgvEvery.Rows[e.RowIndex].Cells["date"].Value).ToShortDateString());
            _total = Convert.ToDouble(dgvEvery.Rows[e.RowIndex].Cells["total"].Value);
        }
        catch (Exception)
        {
        }
    }
