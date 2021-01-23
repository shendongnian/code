       OracleConnectionService OraCon = new OracleConnectionService();
                var cc = ConfigurationManager.ConnectionStrings["OracleProdContext"].ToString();
           OracleConnection _con = new OracleConnection(cc);
           OracleConnection = _con;
           TextCommandType = System.Data.CommandType.Text;
                         var resultSet = OracleHelper.ExecuteScalar(OraCon.OracleConnection, OraCon.TextCommandType, OracleQuery);
     var result = resultSet.Tables[0];
