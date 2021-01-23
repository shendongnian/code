    private void FillCombo(ComboBox myComboBox, List<string> list);
    {
        foreach (string listItem in myList)
        {
             myComboBox.Items.Add(listItem);
        }
        //alternatively, you can add it like fubo suggested in comment
        //myComboBox.Items.AddRange(myList.ToArray());
    }
