            public void Query()
            {
                Match m = Regex.Match(QueryInput.queryString, @"^\s*(?i:select).*$");
                if (!m.Success)
                {
                    QueryInput.queryString += " RETURNING 1";
                }
                NpgsqlCommand cmd = new NpgsqlCommand(QueryInput.queryString, _dbConn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cmd.CommandType = System.Data.CommandType.Text;
                
                try
                {
                    da.Fill(Data);
                }
                catch (Exception e)
                {
                    m = Regex.Match(e.Message.ToString(), @"^(?<code>.*?): (?<msg>.*?)$");
                    if (m.Success)
                    {
                        ErrorCode = m.Groups["code"].Value.ToString();
                        ErrorMessage = m.Groups["msg"].Value.ToString();
                    }
                    else
                        throw e;
                }
                da.Dispose();
                cmd.Dispose();
            }
        }
