    Session["query"] = db.generate_query(parameter1, parameter2, parameter3, parameter4);
    using(SqlConnection conn = new SqlConnection("Data Source=USER-PC;Initial Catalog=ISMS;Integrated Security=True"))
    {
        using(SqlCommand cmd1 = new SqlCommand(Session["query"].ToString(), conn))
        {
            using(SqlDataAdapter sdal = new SqlDataAdapter(cmd1))
            {
                dt_table = new DataTable();
                sdal.Fill(dt_table);
            }
        }
    }
    foreach (DataColumn column in dt_table.Columns)
    {
        column.ColumnName = column.ColumnName.Replace("_", " " );
    }
    staff_attendance_gridview.Visible = true;
    staff_attendance_gridview.DataSource = dt_table;
    staff_attendance_gridview.DataBind();
    result_message.Text = dt_table.Rows.Count + " rows in the table";
