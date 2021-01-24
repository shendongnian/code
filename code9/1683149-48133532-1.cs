    public DataTable GET_PAYMENTS(int? Patient_no, DateTime fromdate, 
    DateTime todate)
    {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Patient_no", SqlDbType.Int);
            if ( Patient_no.HasValue )
                param[0].Value = Patient_no;
            else
                param[0].Value = DbNull.Value;
 
            param[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            param[1].Value = fromdate;
            param[2] = new SqlParameter("@todate", SqlDbType.DateTime);
            param[2].Value = todate;
            dt = DAL.SelectData("GET_PAYMENTS", param);
            DAL.close();
            return dt;
        }  
        
