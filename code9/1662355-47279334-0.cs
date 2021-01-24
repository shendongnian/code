    SqlDependency dependency = new SqlDependency(command);
    OnChangeEventHandler handler = null;
    handler = (s, e) => dependency_OnChange(s, e, clientid, handler);
    dependency.OnChange += handler;
    public void dependency_OnChange(object sender, SqlNotificationEventArgs e, Guid clientid, OnChangeEventHandler handler) {
        var dependency = (SqlDependency)sender;
        if (e.Type == SqlNotificationType.Change) {
            dependency.OnChange -= handler;
            //subscribe function again
            dependency_Update(clientid);
        }
    }
