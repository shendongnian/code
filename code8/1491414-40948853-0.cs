    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["nothanks"].ConnectionString))
    {
        String query = "INSERT INTO [TimeTest] ([Starttime], [Work_Order]) VALUES (@Starttime, @Work_Order)";
    
        using (SqlCommand CCC = new SqlCommand(query, connection))
        {
            connection.Open();
            CCC.CommandType = CommandType.Text;
    
            CCC.Parameters.Add("@Starttime", SqlDbType.DateTime).Value = DateTime.Now;
    
            // All you need is the value of Work_OrderLabel4 of the selected item so just do it like this. 
            CCC.Parameters.Add("@Work_Order", SqlDbType.Int).Value = (DataList2.SelectedItem.FindControl("Work_OrderLabel4") as Label).Text;
        }
    
        CCC.ExecuteNonQuery();
        }
    }
