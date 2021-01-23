    public class MyViewModel
    {
        public ObservableCollection<MyObject> MyObjects { get; set; }
        public MyViewModel()
        {
            MyObjects = new ObservableCollection<MyObject>
            {
                new MyObject {PropertyA = " AAA 101", PropertyB=" BBBBBB 001" },
                new MyObject {PropertyA = " AAA 102", PropertyB=" BBBBBB 002" },
                new MyObject {PropertyA = " AAA 103", PropertyB=" BBBBBB 003" },
                new MyObject {PropertyA = " AAA 104", PropertyB=" BBBBBB 004" },
                new MyObject {PropertyA = " AAA 105", PropertyB=" BBBBBB 005" },
            };
        }
    }
