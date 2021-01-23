    foreach (DataRow row in <nameremoved>stockDataSet.login)
    {
        //And look for matching usernames
        if (row.ItemArray[0].Equals(changeUserName))
        { 
            object[] returnedArray = row.ItemArray;
            returnedArray[1] = EncryptedPass;
            row.ItemArray = returnedArray;
            MessageBox.Show("Change Success");
            loop = true;
            return;
        }
    }
