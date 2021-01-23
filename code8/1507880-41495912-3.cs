    public List<Dictionary<string, string>> 
    SelectedLineHistory(string partProgram, string machineId, 
                        List<int> Line2, bool orderByDate = false)
    {
        List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
        string query = "SELECT MACHINE_ID, PART_PROGRAM, POSITION_ID, DATE_TIME, SAVE_DATE_TIME,DWELL_STIME, ADJUSTED_AMOUNT, DWELL_OFFSET, EMPL_ID " +
                       "FROM MPCS.WJ_DWELL_OFFSETS_HIST " +
                       "WHERE PART_PROGRAM = ? and MACHINE_ID = ? and POSITION_ID = ? ";
        if (orderByDate)
        {
            query += " order by save_date_time desc, position_id asc";
        }
        List<OleDbParameter> queryParameters = new List<OleDbParameter>();
        foreach (var line in Line2)
        {
            //actually should define parameter outside the loop and just assign the value here
            queryParameters.Clear();
            queryParameters.Add(new OleDbParameter("PART_PROGRAM", partProgram));
            queryParameters.Add(new OleDbParameter("MACHINE_ID", machineId));
            queryParameters.Add(new OleDbParameter("POSITION_ID", Line));
            results.Add(this.ExecuteParameterQuery(query, queryParameters));        
        }
        return (results);
    }
