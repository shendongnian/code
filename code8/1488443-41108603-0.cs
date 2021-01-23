    private void FavoriteButton_Click(object sender, RoutedEventArgs e)
    {
        if (listobj.Any(l => l.AnswerName == AnswerTextBlock.Text))
            return;
        //add
        listobj.Add(new MyData { AnswerName = AnswerTextBlock.Text });
        //sort (does not modify the original listobj instance!)
        var sortedList = listobj.OrderBy(item => item.ToString()).ToList();
    
        //clear and re-add all items in the sorted order
        listobj.Clear();
        foreach( var item in sortedList )
        {
            listobj.Add( item );
        }
                
        using (IsolatedStorageFileStream fileStream = Settings1.OpenFile("MyStoreItems", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(MyDataList));
            serializer.WriteObject(fileStream, listobj);
    
        }
    }
