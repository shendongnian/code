    public List<string> dataTableToString(DataTable table)
            {
                List<string> Labels = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    //index of row you want returned in the list
                    Labels.Add(row[2].tostring())
                }
             return labels
             }
    public List<string> whateverInformationYouWantHere(string labelID,)
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT * FROM LABELS WHERE LabelID = @labelID";
                command.Parameters.AddWithValue("labelID", labelID);
                return dataTableToString(Databasehandler.SelectData(command));
            }
