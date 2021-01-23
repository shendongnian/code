    DataTable dt = new Datatable(); // Lets this datatable have data;
    Datatable dt2 = new Datatable(); // Copy all matching rows
    foreach (DataRow dr in dt.Rows)
    {
    if (dr["From_Station_Code"].ToString() == "DBY" && dr["To_Station_Code"].ToString() == "MAT")
    {
        dt2.Rows.Add(dr);
    }
    }
    GridViewTrainTimes.DataSource = dt;
    GridViewTrainTimes.DataBind();
