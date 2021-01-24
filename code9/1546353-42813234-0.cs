    ComputerList.CollectionChanged += (s, e) => NotifyPropertyChanged("WorkingItems");
    this.PropertyChanged += (s, e) => { if (e.PropertyName == "ComputerList") NotifyPropertyChanged("WorkingItems"); };
    foreach (var item in ComputerList)
    {
        item.PropertyChanged += (s, e) => { if (e.PropertyName == "isWorking") NotifyPropertyChanged("WorkingItems"); };
    }
