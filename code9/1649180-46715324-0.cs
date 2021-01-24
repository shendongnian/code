      ListNumbers = new ObservableCollection<string>();
     public async void StoreNum()
    {   
    var num = await ScanCodeVM.CodePage(); // returns a string
    if (num != null)
    {
        ListNumbers.Add(num);     
    }
    }
     // do something with that list.
