        cmd.Parameters.Add("@USER_ID", SqlDbType.Int).value = "(somthing)";
        cmd.Parameters.Add("@PASS", SqlDbType.Int).value = "(somthing)";
        using (SqlDataReader sdr = cmd.ExecuteReader()) 
        {
            UserType = reader.GetString(Column Index); //<= try not to type hard string this will return the string value of the column index you enter 
                if (UserType == "Administrator")
                {
                    bunifuFlatButton3.Visible = true;
                }
                else if (UserType == "StockController")
                {
                    bunifuFlatButton3.Visible = false;
                }
        }
