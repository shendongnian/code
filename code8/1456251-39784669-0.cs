    private void PrepUpdate()
    {
        LicenceBL lbl = new LicenceBL(0);
        DataSet lds = new DataSet();
        lbl.FetchForEdit(lds, AgentId,BrokerId);
        HashSet<string> values = new HashSet<string>();
        for (int i = 0; i < lds.Tables[0].Rows.Count; i++)
        {
            values.Add(lds.Tables[0].Rows[i]["LicenceTypesNames"].ToString());
        }
        txtLicenseType.Text = string.Join(", ", values.ToList());
    }
