	try
	{
		await sqlconn.OpenAsync();
		using (SqlDataAdapter dp = new SqlDataAdapter(commandtext, sqlconn))
		{
			dp.SelectCommand.CommandTimeout = 0;
			await Task.Run(() => (Action)delegate {
				dp.Fill(dt);
				ResultList.ItemsSource = dt.DefaultView;
				lblMsg.Content = "Query executed successfully";
				lblMsg.Foreground = new SolidColorBrush(Colors.Black);
				sqlconn.Close();
			});
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show(string.Format("Exception in the Query ::--> {0} \n\n StackTrace ::--> {1} ", ex.Message, ex.StackTrace));
	}
