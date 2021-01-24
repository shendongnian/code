                var _sMsg = new SqlParameter("sMsg", "")
                {
                    Direction = ParameterDirection.Output,
					DbType = DbType.String,
					Size = 500
                };
                var sql = "exec sp_foo @sUserId, @sMsg OUTPUT";
                var dr = _ctx.Database.ExecuteSqlQuery(sql, _sUserID, _sMsg);
                return _sMsg.Value.ToString();
