    public TimeSpan differenceDate(string idAdmission)
    {
        // Declaring as a constant
        const string ReQuete = "SELECT AdmitDate FROM AdmissionRecords WHERE AdmissionID = @idAdmission";
        SqlCommand commande = null;
        try
        {
            connexion.Open();
            commande = new SqlCommand(ReQuete, connexion);
            // I am making the assumption that the AdmitDate is a Date field,
            // if it is a string, then just change this to string and check
            // for null before parsing it.  Note also that I am using the
            // ExecuteScalar method since you are running a scalar query.
            // This way you don't have to create a reader and have the
            // additional cleanup code associated with a reader
            DateTime? result = (DateTime?)commande.ExecuteScalar();
            if (result.HasValue)
            {
                return result.Value - DateTime.Now.TimeOfDay;
            }
            else
            {
                return TimeSpan.Zero; // I think this is probably what you would want as the default return value if there is no date
            }
        }
        finally
        {
            // If an object implements IDisposable, you should call Dispose
            // or place it in a using statement
            commande?.Dispose(); // Newer C# syntax, old was if (commande != null)
            // we should be sure the connection is open before closing it
            if (connexion.State == Connection.Open) connexion.Close();
        }
    }
