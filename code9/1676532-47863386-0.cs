    bool TryingtoStart = true;
    while (TryingtoSTart)
    {
        using(var dbc = new SQLiteConnection(connectionString))
        {
            try
            {
                 using(var departmentDataAdapter = new SQLiteDataAdapter("select * from DEPARTMENT", dbc))
                 {
                      // etc
                 }
                 
                // Note: This row will only be executed if there where no exceptions until this point in the code
                TryingtoStart = false;
            }
            catch (SQLiteException ex)
            {
                
                if (MetroFramework.MetroMessageBox.Show(this,  ex.Message.ToString(), "Database error", MessageBoxButtons.RetryCancel) == DialogResult.Cancel) Application.Exit();
            }
            catch (Exception exc)
            {
                if (MetroFramework.MetroMessageBox.Show(this,  exc.Message.ToString(), "Exception", MessageBoxButtons.RetryCancel) == DialogResult.Cancel) Application.Exit();
            }
        }
    }
