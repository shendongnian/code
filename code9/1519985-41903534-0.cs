    double sum = 0;
    dt = ds.Tables["bug_tasks"];
    foreach (DataRow dr in dt.Rows)
    {
        sum += System.Convert.ToDouble(dr["time"]);
    }
    Response.Write(sum);
