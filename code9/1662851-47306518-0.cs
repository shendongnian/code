    DataTable DT = new DataTable();    
    public static DataTable ExecSelect(string Leerling)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter DA;
            DA = new SqlDataAdapter(Leerling, SQLString.Conn);
            DS.Clear();
            DA.Fill(DS);
            // 1e tabel uit database
            DT = DS.Tables[0];
            return DT;
        }
