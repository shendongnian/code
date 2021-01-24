    private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        SqlDependency dependency = (SqlDependency)sender;
        dependency.OnChange -= new OnChangeEventHandler(dependency_OnChange);
        if (e.Type == SqlNotificationType.Change)
            TransactionHub.GetUnregTransactions(GetUnregisteredTransactions());
    }
