    using (var con = new MySqlConnection(MySQLConStr))
    {
        con.Open();
        using (MySqlCommand cmd = new MySqlCommand("Alerts_GetAlerts(@managerID)", con))
        {
            cmd.Parameters.AddWithValue("@managerID", managerID);
            using (var dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var alert = new AlertsModel
                    {
                        ID = Convert.ToInt32(dataReader[0]),
                        Type = Convert.ToInt32(dataReader[1]),
                        ManagerID = Convert.ToInt32(dataReader[2]),
                        EmployeeID = Convert.ToInt32(dataReader[3]),
                        HolidayID = Convert.ToInt32(dataReader[4]),
                    };
                    AllAlerts.Add(alert);
                }
            }
        }
        return AllAlerts;
    }
