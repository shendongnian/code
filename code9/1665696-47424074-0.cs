    class Father
    {
        string myName;
        public string MyName
        {
            get { return myName; }
            set { myName = value; }
        }
        public Father()
        {
            myName = "John";
        }
    }
    class FirstSon : Father
    {
        string mySecondName;
        public string MySecondName
        {
            get { return mySecondName; }
            set { mySecondName = value; }
        }
        public FirstSon()
        {
            mySecondName = "Bill";
        }
    }
    class SecondSon : Father
    {
        int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        string mySecondName;
        public string MySecondName
        {
            get { return mySecondName; }
            set { mySecondName = value; }
        }
        public SecondSon()
        {
            mySecondName = "Drake";
            age = 21;
        }
    }
