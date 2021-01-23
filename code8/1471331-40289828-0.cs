            var dbConnection = "datasource=127.0.0.1;port=3306;username=root;password=12345";
			using (var conDataBase = new MySqlConnection(dbConnection))
			using (var selectCommand = new MySqlCommand("select GUID,BanTime,Reason from bans.bans order by BanType asc", conDataBase)) {
				var dbReader = selectCommand.ExecuteReader();
				using (var file = new System.IO.StreamWriter(@"C:\Users\mccla\Desktop\A3Bans.txt", true)) {
					while (dbReader.Read()) {
						file.Write(dbReader.GetValue(0).ToString());
					}
				}
			}
