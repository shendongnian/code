    string[] fileNames = Directory.GetDirectories(folderLocation).Where(x=>!x.Contains("Cobol")).ToArray();
        foreach (string fileName in fileNames)
        {
            item = new ListItem();
            item.Value = item.Text = "Add " + fileName.Substring(startSize);
            CheckBoxList1.Items.Add(item);
            CheckBoxList2.Items.Add(item);
            CheckBoxList3.Items.Add(item);
