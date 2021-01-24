        void Main()
        {
            var d = GetDictionary();
        }
        Dictionary<string,UserInfo> GetDictionary()
        {
            var l = new List<UserInfo>() {
                new UserInfo("One", "There"),
                new UserInfo("Two", "SomewhereB"),
                new UserInfo("Three", "SomewhereA"),
                new UserInfo("Four", "Here")
            };
            var comp = new UserInfoComparer();
            l.Sort(comp);
            return  l.ToDictionary( e => e.Name);
        }
        public class UserInfo
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public UserInfo(string name, string location)
            {
                Name = name;
                Location = location;
            }
        }
        public class UserInfoComparer: IComparer<UserInfo>{
            public int Compare(UserInfo x, UserInfo y)
            {
                var r = x.Location.CompareTo(y.Location);
                if (r == 0)
                {
                    r = x.Name.CompareTo(y.Name);
                }
                return r;
            }
        }
