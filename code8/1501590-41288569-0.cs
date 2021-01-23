    DataTable dt = new DataTable();
    dt.Columns.Add("PracticeID",typeof(int)); //THIS IS THE IMPORTANT BIT
    dt.Columns.Add("AuthorID");
    //add data(in real code, this is pulled from the database)
    dt.Rows.Add(1, 87);
    dt.Rows.Add(37, 202);
    dt.Rows.Add(1, 268);
    dt.Rows.Add(7, 262);
    //get distinct practiceids into datatable
    DataView dv = new DataView(dt);
    DataTable dtDistinctIDs = dv.ToTable(true, "PracticeID");
    //for each practice, get a list of the authors
    foreach (DataRow practiceRow in dtDistinctIDs.Rows)
    {
        DataRow[] dra = dt.Select("PracticeID = " + (int)practiceRow["PracticeID"]);
    }
