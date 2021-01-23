        public class Phone
        {
            public string Type { get; set; }
            public string ToggleButton { get; set; }
            public string ColorButton { get; set; }
        }
        public class SmartPhones
        {
            private List<Phone> _list;
            public SmartPhones()
            {
                _list.Add(new Phone{ Type = "Sony", ToggleButton = "aa", ColorButton = "bb"});
                _list.Add(new Phone { Type = "Sony", ToggleButton = "aa", ColorButton = "bb" });
                _list.Add(new Phone { Type = "Sony", ToggleButton = "aa", ColorButton = "bb" });
            }
        }
