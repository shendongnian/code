        public List<EmpModel> GetAllEmployees()
        {
            connection();
            con.Open();
            IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(con, "GetEmpUsingDapper1").ToList();
            con.Close();
            //var data1 = EmpList.ToList();
            return EmpList;
        }
