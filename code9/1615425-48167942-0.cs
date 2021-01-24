    try
    {
       cmd.ExecuteNonQuery();
    }
    catch (System.ArgumentException ex)
    {
       if (ex.TargetSite.Name == "DecryptSymmetricKey" && ex.InnerException == null)
       {
                        InitializeAzureKeyVaultProvider() //Register the Provider
                        cmd.ExecuteNonQuery(); // Try the query again.
       }
    }
