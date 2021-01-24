    foreach (DataRowView item in sknBox.SelectedItems)
    {
        Console.WriteLine(item.Row["ID"].ToString());
        Console.WriteLine(item.Row["Description"].ToString());
    }
