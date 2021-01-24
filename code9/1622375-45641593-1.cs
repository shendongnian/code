        public class Person
    {
        public Person(string first, string last, PhoneNumber home, PhoneNumber cell)
        {
            First = first;
            Last = last;
            HomeNumber = home;
            CellNumber = cell;
        }
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int HomePhone_ID { get; set; }
        public int CellNumber_ID { get; set; }
        public virtual PhoneNumber HomeNumber { get; set; }
        public virtual PhoneNumber CellNumber { get; set; }
    }
    }
