    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable table9x9 = new DataTable();
            if (table9x9.Columns.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                        table9x9.Columns.Add(" ");
                    else
                        table9x9.Columns.Add(i+"");
                }
            }
            for (int row = 1; row <= 9; row++)
            {
                DataRow dr = table9x9.NewRow();
                for (int column = 0; column <= 9; column++)
                {
                    if (column == 0)
                        dr[" "] = row;
                    else
                        dr[column + ""] = row * column;
                }
                table9x9.Rows.Add(dr);
            }
            GridView2.DataSource = table9x9;
            GridView2.DataBind();
        }
    }
