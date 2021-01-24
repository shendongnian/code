            public List<Combination> GetData(int userId)
            {
                String query = "select * from myview" + " where userId = " + userId + ";";
                using (System.Data.Common.DbConnection _Connection = database.Connection)
                {
                    _Connection.Open();
                    return _Connection.Query<Combination>(query).ToList();
                }
            }
