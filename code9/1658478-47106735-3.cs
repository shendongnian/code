    public class Example
    {
        public static Example Instance1 = new Example (0, "A");
        public static Example Instance2 = new Example (1, "B");
        //Must have this default constructor!
        protected Example()
        {//... Add code if needed
        }
        protected Example(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        private int value;
        private string name;
    }
