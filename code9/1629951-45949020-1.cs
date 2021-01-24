    System.IO.StreamReader fileReader = new System.IO.StreamReader(csvPath, false);
    string[] fileDataField;
    string fileRow;
    //Reading Data
    while (fileReader.Peek() != -1) {
        fileRow = fileReader.ReadLine();
        fileDataField = fileRow.Split(';');
        //Declare List to temporary store the values
        List<string> tempItems = new List<string>();
        //Loop through the array and do comma check,
        //Cut the string if there's a comma in it
        //Else just add the normal value
        foreach (var item in fileDataField) {
            if (item.Contains(",")) {
                tempItems.Add(item.Substring(item.LastIndexOf(",") + 1));
            }
            else {
                tempItems.Add(item);
            }
        }
        dataGridView1.Rows.Add(tempItems);
    }
    fileReader.Dispose();
    fileReader.Close();
