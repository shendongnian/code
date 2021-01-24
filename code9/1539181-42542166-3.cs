        try
        {
            if (File.Exists(inputFilename))
            {
                // do something
                File.WriteAllText(path, contents);
            }
            else
            {
                // do somthing
            }
        }
        catch (DirectoryNotFoundException dirNotFoundEx)
        {
            MessageBox.Show("Directory does not exist.Try to use diffrent folder.");
        }
        catch (Exception ex)
        {
            _eventLog.WriteEntry(string.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace), EventLogEntryType.Error);
        }
    }
