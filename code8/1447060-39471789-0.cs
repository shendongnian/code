    //declare DateTime lastErrMsg = DateTime.MinValue; at your class level
    catch (FormatException fEX)
    { 
        if (DateTime.Now - lastErrMsg > TimeSpan.FromSeconds(30)) //or whatever TimeSpan value
        {
            Message.Box("Value must be a divisisable by 1 exactly")
            lastErrMsg = DateTime.Now;
        }
    }
