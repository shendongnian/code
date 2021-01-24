    public ObservableCollection<Communication> GetCommunications()
    {
        DataSet ds = StoreDbDataSet.ReadDataSet();
        ObservableCollection<Communication> communications = new ObservableCollection<Communication>();
        foreach (DataRow communicationRow in ds.Tables["Communications"].Rows)
        {
            var c = new Communication((ushort)Convert.ToInt16(communicationRow["ModelNumber"]), communicationRow["ParamName"].ToString(),
                    ds.Tables["ParamValue"].Rows[0][0].ToString(), communicationRow["DefaultValue"].ToString(), communicationRow["MaxValue"].ToString(),
                    communicationRow["MinValue"].ToString());
            foreach (DataRow dr in ds.Tables["ParamValue"].Rows)
            {
                c.ParamValues.Add(dr[0].ToString());
            }
            communications.Add(c);
        }
        return communications;
    }
