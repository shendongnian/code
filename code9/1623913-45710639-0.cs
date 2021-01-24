    public void GetAudits(Guid? userId, DateTime? from, DateTime? to, string form)
    {
        StringBuilder sCondition = new StringBuilder("WHERE 0=0");
        if (userId != null && userId != Guid.Empty)
            sCondition.Append(string.Format(" AND UserId = '{0}' ", userId));
        if (!string.IsNullOrEmpty(form))
            sCondition.Append(string.Format(" AND FormName = '{0}' ", form));
        string query = string.Format("SELECT * FROM Common.TbHistoryLog {0}", sCondition);
        if (Audits != null)
        {
            Audits.Clear();
            var newItems = oContext.Database.SqlQuery<HistoryLog>(query).ToList();
            if (newItems != null)
                foreach (var newItem in newItems)
                    Audits.Add(newItem);
        }
    }
