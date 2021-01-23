            using (var con = new SqlConnection(_connectionstring))
            {
                con.Open();
                var cmd = new SqlCommand(<NameOfStoredProcedure>, con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add("@param", DbType.String).Value = <yourParamValue>;
                var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    return new YourDataModel(
                        rdr.GetGuid(0),
                        rdr.GetInt32(1)
                }
                return null;
            }
