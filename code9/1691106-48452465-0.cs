    private void DataRecieved_Created(object sender, FileSystemEventArgs e)
    {
       if ( System.IO.File.Exists(e.FullPath )) // Might Be a Directory
       {
       var data = File.ReadAllText(e.FullPath);
       data = ProcessMessageMCOINToADDN(data);
       if (DataRecieved != null)
       {
          MessageData tempmessage = new MessageData
          {
             MyEventString = data
          };
          DataRecieved?.Invoke(this, tempmessage);
       }
        File.Delete(e.FullPath);
    
        }
    }
