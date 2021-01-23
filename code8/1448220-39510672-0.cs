        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //fill the datatable from the database
                DataTable dt = //fill the table here...
                //bind the table to the grid
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //loop all the datatable columns to fill the checkboxlist
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    CheckBoxList1.Items.Insert(i, new ListItem(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName, true));
                }
            }
        }
        protected void CheckBoxList1_TextChanged(object sender, EventArgs e)
        {
            //loop all checkboxlist items
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected == true)
                {
                    //loop all the gridview columns
                    for (int i = 0; i < GridView1.Columns.Count; i++)
                    {
                        //check if the names match and hide the column
                        if (GridView1.HeaderRow.Cells[i].Text == item.Value)
                        {
                            GridView1.Columns[i].Visible = false;
                        }
                    }
                }
            }
        }
