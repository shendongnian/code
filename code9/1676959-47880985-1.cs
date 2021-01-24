     public void Employee_Insert(string a, string b, int c , int d)
        {
            SqlParameter[] param1 = { 
                                    new SqlParameter("@Name",a),
                                    new SqlParameter("@Address",b),
                                    new SqlParameter("@Age",c),
                                    new SqlParameter("@country",d)
                                    };
            _dal.sendonly("usp_Employee_insert", param1);
        }
