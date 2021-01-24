    var csvPath = csvPath;
    System.IO.StreamReader fileReader = new System.IO.StreamReader(csvPath, false);
    string[] fileDataField;
    string fileRow;
    //Reading Data
    while (fileReader.Peek() != -1) {
        fileRow = fileReader.ReadLine();
        fileDataField = fileRow.Split(';');
        List<string> tempItems = new List<string>();
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
