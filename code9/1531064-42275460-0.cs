  		public string _ConexaoBcoDados = "Data Source=10.10.40.12\\DESENV;Initial Catalog=control_db;Uid=usr_desenv14; pwd=12345678;";
            sql.AppendLine("select login_rede,perfil_id from protocol_tb with(nolock) ");
            using (var conn = new SqlConnection(_ConexaoBcoDados))
            {
                var cmd = new SqlCommand(sql.ToString(), conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        valores = new string[] { reader["login_rede"].ToString(), reader["perfil_id"].ToString() };
                    }
                }
            }
