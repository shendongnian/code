    public void yourMethodName()
        {
            string connection = @"datasource = localhost; database=sub; Uid=root; Password=steph";
            MySqlConnection connect = new MySqlConnection(connection);
            string yourQuery = null;
            yourQuery = "SELECT top 1 * from sub.transmittal_transaction WHERE id=@id";
            dbCommand.Parameters.Add("@id", SqlDbType.Int);
            dbCommand.Parameters["@id"].Value = yourtextboxnamehere.Text; // or = your labelname.text
            MySqlCommand executeQuery = new MysqlCommand(yourQuery, connect);
            connect.open;
            MySqlDataReader datareader = executeQuery.ExecuteReader();
            try
            {
                if (datareader.HasRows)
                {
                    datareader.Read();
                    yourtextboxnamehere.Text = datareader["id"].ToString();
                    startDate.text = datareader["yourStartDateColumnNameHere"].ToString(); // if your using a label it still ends in .text same goes with using textbox to display it on the form.
                    endDate.text = datareader["yourEndDateColumnNameHere"].ToString(); // if your using a label it still ends in .text same goes with using textbox to display it on the form.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
