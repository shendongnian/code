    try
    {
        SqlDataAdapter dp = new SqlDataAdapter(commandtext, sqlconn);
        await sqlconn.OpenAsync();
        await Task.Delay(3000); //<--
        dp.SelectCommand.CommandTimeout = 0;
        DataSet ds = new DataSet();
        dp.Fill(ds, "QueryData");
        dt = ds.Tables["QueryData"];
        ResultList.ItemsSource = dt.DefaultView;
        sqlconn.Close();
        lblMsg.Content = "Query executed successfully";
        lblMsg.Foreground = new SolidColorBrush(Colors.Black);
    }
    catch (Exception ex)
    {
        MessageBox.Show(string.Format("Exception in the Query ::--> {0} \n\n StackTrace ::--> {1} ", ex.Message, ex.StackTrace));
    }
