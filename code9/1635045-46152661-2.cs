    private void DeleteSelectedItemListBox()
    {    
        var deletingNumber = YourList.IndexOf(YourSelectedItem);
        var allLines = File.ReadAllLines(path).ToList();
        allLines.RemoveAt(deletingNumber);
        File.WriteAllLines(path,allLines.ToArray());
    }
