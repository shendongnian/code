    public List<Dictionary<string, string>> 
    SelectedLineHistory(string partProgram, string machineId, 
                        List<int> Line2, bool orderByDate = false)
    {
        List<Dictionary<string, string>> results;
        string query = "";
        List<OleDbParameter> queryParameters = new List<OleDbParameter>();
        foreach (var line in Line2)
        {
            query = "SELECT MACHINE_ID, PART_PROGRAM, POSITION_ID, DATE_TIME, SAVE_DATE_TIME,DWELL_STIME, ADJUSTED_AMOUNT, DWELL_OFFSET, EMPL_ID ";
            query += "FROM MPCS.WJ_DWELL_OFFSETS_HIST ";
            query += "WHERE PART_PROGRAM = ? and MACHINE_ID = ? and POSITION_ID = ?";
            if (orderByDate)
            {
                query += " order by save_date_time desc, position_id asc";
            }
            queryParameters.Add(new OleDbParameter("PART_PROGRAM", partProgram));
            queryParameters.Add(new OleDbParameter("MACHINE_ID", machineId));
            queryParameters.Add(new OleDbParameter("POSITION_ID", Line2));
            results = this.ExecuteParameterQuery(query, queryParameters);        
            return (results);
        }
    }
