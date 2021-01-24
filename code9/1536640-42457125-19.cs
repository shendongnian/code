    //Property Changed will be called whenever a property of one of the 'Person'
    //objects is changed.
    private void person_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        var row = sender as Person;
        SaveData(row);
    }
    
    private void SaveData(Person row)
    {
        //Save the row to the database here.
    }
