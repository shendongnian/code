    public void UpdateBeginStir()
    {
        string beginStir = null;
        string connectionString = "(Omitted)";
        string commandLine = "SELECT MAX(Event_Time) AS Time " +
                             "FROM dbo.Custom_EventLog " +
                             "WHERE Container_ID = @LOTNUMBR " +
                             "AND Event_ID = 1 " +
                             "GROUP BY BadgeNo, Container_ID, Event_ID";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(commandLine, connection))
            {
                command.Parameters.Add("@LOTNUMBR", SqlDbType.Int);
                command.Parameters["@LOTNUMBR"].Value = Convert.ToInt32(TextBoxLot.Text);
                beginStir = (string)command.ExecuteScalar();
            }
        }
        MessageBox.Show(beginStir, "test", MessageBoxButton.OK);
        LabelBeginStir.Content = beginStir;
    }
