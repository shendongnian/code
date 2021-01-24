    try
    {
        // ...
        Scope.Commit();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
        Scope.Rollback();
    }
