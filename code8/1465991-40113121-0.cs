    class MainClass
    {
        public string someMethod()
        {
            Type type = this.GetType(); //SubClass
            return "";
        }
    }
    class SubClass : MainClass
    {
        public int someField;
    } 
