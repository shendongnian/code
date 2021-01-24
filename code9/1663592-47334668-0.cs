    // Code requires directives to
    // System.Security.Permissions and
    // System.Data.SqlClient
    private bool CanRequestNotifications()
    {
        SqlClientPermission permission =
            new SqlClientPermission(
            PermissionState.Unrestricted);
        try
        {
            permission.Demand();
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
