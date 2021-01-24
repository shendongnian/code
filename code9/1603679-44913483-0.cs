    class Helper
    {
        private NameValueCollection Dostuff()
        {
            string name = "valves";
            int num = 5;
            NameValueCollection collection = new NameValueCollection();
            collection.Add("Sam", "Dot Net Perls");
            collection.Add("Bill", "Microsoft");
            return collection;
        }
        public NameValueCollection GetCollection()
        {
            return Dostuff();
        }
    }
