    string key = month + "TotalAmount"; 
    decimal tempDec = Convert.ToDecimal(Properties.Setting.Default[key]); // Creates a decimal to store the setting variable in using the key to access the correct setting variable
    tempDec += Convert.ToDecimal("EnteredAmount"); // Adds the value of the Setting variable to the amount entered. 
    Properties.Settings.Default[key] = tempDec; // Then sets the Setting variable to equal the temp variable.
    Properties.Setting.Default.Save();
