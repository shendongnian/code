    while (DBReader.Read())
    {
        List<string> mylist = new List<string>();
        for(int i=0; i<DBReader.FieldCount; i++)
            myList.Add(DBReader.GetValue(i).ToString());
    
        foreach (var item in mylist)
        {
            MessageBox.Show("The details are " + item);
        }  
    }
