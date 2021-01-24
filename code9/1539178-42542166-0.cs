    try
    {
          if (File.Exists(inputFilename))
          {
             // do something
             File.WriteAllText();
          }
          else
          {
             // do somthing
          }
    }
    catch (DirectoryNotFoundException dirNotFound)
    {
            MessageBox.Show("Directory does not exist.Try to use diffrent folder.");
    }
    catch (Exception ex)
    {
           _eventLog.WriteEntry(ex.Message + "\r\n" + ex.StackTrace, EventLogEntryType.Error);
    }
