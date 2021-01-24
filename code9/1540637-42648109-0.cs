    try
    {
         var operation = appFile.File.CopyAsync(ApplicationData.Current.LocalFolder, appFile.File.DisplayName, NameCollisionOption.GenerateUniqueName);
                            
    }
    catch (Exception ex)
    {
         System.Diagnostics.Debug.WriteLine("exception msg: "+ex.Message);
    }
