    public class MyViewModel
    {
        public List<string> MyList { get; set; }
        public string MyListAsString
        {
            get
            {
                return string.Join(",", MyList);
            }
            set
            {
                MyList = value.Split(new char[] { ',' }).Select(x => x.Trim()).ToList();
            }
        }
    }
