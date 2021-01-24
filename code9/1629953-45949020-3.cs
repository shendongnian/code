    System.IO.StreamReader fileReader = new System.IO.StreamReader(csvPath, false);
    string[] fileDataField;
    string fileRow;
    //Reading Data
    while (fileReader.Peek() != -1) {
        fileRow = fileReader.ReadLine();
        fileDataField = fileRow.Split(';');
        //Declare temporary array to temporary store the values
        string[] tempItems = new string[fileDataField.Length];
        //Loop through the array and do comma check,
        //Cut the string if there's a comma in it
        //Else just add the normal value
        for (int i = 0; i < fileDataField.Length; i++) {
            tempItems[i] = fileDataField[i].Substring(fileDataField[i].LastIndexOf(",") + 1);
        }
        dataGridView1.Rows.Add(tempItems);
    }
    fileReader.Dispose();
    fileReader.Close();
