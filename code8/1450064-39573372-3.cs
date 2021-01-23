    var notes = new ObservableCollection();
    using(DataReader reader = cmdNotes.ExecuteReader())
    {
        var ordinals = new 
        { 
            Id = reader.GetOrdinal("NoteID"),
            Name = reader.GetOrdinal("NoteName")
        }
        while(reader.Read() == true)
        {
            var temp = new Note();
            temp.Id = reader.GetString(ordinals.Id);
            temp.Name = reader.GetString(ordinals.Name);
            notes.Add(temp);
        }
    }
    noteNamesList.SelectedValuePath = "Id";
    noteNamesList.DisplayMemberPath = "Name";
    noteNamesList.ItemsSource = notes;
