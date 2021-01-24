                var _sMsg = new SqlParameter("sMsg", "")
                {
                    Direction = ParameterDirection.Output,
					DbType = DbType.String,
					Size = 500
                };
                var sql = "exec sp_foo @sUserId, @sMsg OUTPUT";
                var dr = _ctx.Database.ExecuteSqlQuery(sql, _sUserID, _sMsg);
                
                //here you can retrive your table
                while (dr.DbDataReader.Read())
                {
                    var bar = dr.DbDataReader[0].ToString();
                }
                //here is your OUTPUT
                return _sMsg.Value.ToString();
