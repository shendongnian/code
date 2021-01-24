    SqlDataTable dt = new SqlDataTable();
    SqlCommand comm = new SqlCommand(query, conn);
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = comm;
    da.Fill(dt);
    myCMB.DataSource = dt.Copy();
    myCMB.DisplayMember = "display";
    myCMB.ValueMember = "value;
