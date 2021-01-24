                var _sMsg = new SqlParameter("sMsg", "")
                {
                    Direction = ParameterDirection.Output,
                    DbType = DbType.String,
                    Size = 500
                };
                var sql = "exec sp_foo @sMsg OUTPUT";
                var dr = _context.Database.ExecuteSqlCommand(sql, _sMsg);
