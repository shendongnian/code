    string longestName = "";
    foreach (string possibleDate in comboBox1.Items)
    {
        int stringLength = possibleDate.Length;
        if(stringLength > longestName.Length)
            longestName = possibleDate;
    }
