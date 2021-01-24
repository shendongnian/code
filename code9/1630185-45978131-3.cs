             try {
                               StorageFile myFile = await folder.GetFileAsync(name);
                               await Windows.Storage.FileIO.WriteTextAsync(myFile,  "myStringContent");
                               
                                   }
                           catch (Exception e)
                           {
                               Debug.WriteLine("Failure: "+e.Message);
           
                               return;
                           }
 
