    //Every object instance in C# have the function 'ToString'.
    string[] test = values[5].ToString().Split('|');
    
    foreach (string key in test)
    {
        purgeRecord = new PurgeRecord()
        {
            //Create an array to insert in the values, but probably this is the KeyName
            KeyValues = new[] { key },
            IsValid = true,
            FileName = "XYZ"
        };
        lstPurgeRecords.Add(purgeRecord);
    }
