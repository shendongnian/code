    OleDbCommand cmd = new OleDbCommand(" SELECT ID, RemainingDept FROM Dept_Tbl ORDER BY RemainingDept", conn);
    OleDbDataReader dr = cmd.ExecuteReader();
    while (dr.Read())
    {
        var dept = new Department()
        {
            ID = Convert.ToInt32(dr["ID"]),
            RemainingDept = Convert.ToInt32(dr["RemainingDept"]);
        };
        liste.Add(dept);
    }
