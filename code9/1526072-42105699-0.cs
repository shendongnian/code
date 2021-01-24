      public DataTable GetRandomQuestion(int id, int z)
        {
            ArrayList sqlParameterArrayList = new ArrayList();
           
            SqlParameter sqpID = new SqlParameter("a", SqlDbType.Int);
            sqpID.Value = id;
            sqlParameterArrayList.Add(sqpID);
            SqlParameter sqpZ = new SqlParameter("b", SqlDbType.Int);
            sqpZ.Value = z;
            sqlParameterArrayList.Add(sqpZ);
            return DAO.GetTable("GetRandomQuest", sqlParameterArrayList);
        }
