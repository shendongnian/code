    private class Temp
        {
            public string MainName { get; set; }
            // This is probably the key point here - I create a property to
            // hold data to bind my radio buttons to
            public List<string> RadioButtonOptions { get; set; }
        }
        private string getRandomString(Random r)
        {
            var sb = new StringBuilder();
            int length = r.Next(3, 10);
            for (int i = 0; i < length; i++)
            {
                int chr = r.Next(0, 60);
                char result = (char)(33 + chr);
                sb.Append(result);
            }
            return sb.ToString();
        }
        private List<string> getRandomListOfStrings(Random r)
        {
            int listLength = r.Next(3, 6);
            var list = new List<string>();
            for (int i = 0; i < listLength; i++)
            {
                list.Add(getRandomString(r));
            }
            return list;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            var list = new List<Temp>
            {
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                },
                new Temp
                {
                    MainName = getRandomString(r),
                    RadioButtonOptions = getRandomListOfStrings(r)
                }
            };
            mainListView.DataSource = list;
            mainListView.DataBind();
