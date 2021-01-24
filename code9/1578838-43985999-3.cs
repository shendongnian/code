    static void Main(string[] args)
    {
        ObservableCollection<string> obj = new ObservableCollection<string>();
        obj.CollectionChanged += (sender, e) => { Console.WriteLine("Changed1"); };
        obj.CollectionChanged += (sender, e) => { Console.WriteLine("Changed2"); };
        obj.Add("value1");  //Changed1, Changed2 raised
        var fi = obj.GetType().GetEventField("CollectionChanged");
        if (fi == null) return;
        fi.SetValue(obj, null);  //remove all event handlers
        obj.Add("value3"); //Nothing raised
    }
