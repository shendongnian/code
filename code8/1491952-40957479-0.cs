    public class MyObject
    {
        public DateTime Date { get; set; }
    }
    
    var list = new ObservableCollection<MyObject>();
    list.Add(new MyObject { Date = new DateTime(2015, 5, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 5, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 5, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 5, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 6, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 6, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 2, 12) });
    list.Add(new MyObject { Date = new DateTime(2015, 2, 12) });
    
    var newList = list.GroupBy(x => x.Date);
