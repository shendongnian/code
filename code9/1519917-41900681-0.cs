        public DateTime GetLocalTime()
        {
            OracleBridge ob = new OracleBridge(_connStr);
            string sqlQuery = "select distinct sysdate from dual";
            DateTime dt = new DateTime();
            try
            {
                dt = Convert.ToDateTime(ob.ExecuteScalar(sqlQuery, CommandType.Text));
            }
            catch (OracleException ex)
            {
                throw ex;
            }
            return dt;
        }
