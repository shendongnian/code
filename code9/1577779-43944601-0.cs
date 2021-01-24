    public class Parent
    {
        internal bool IsOpen;
        public Parent(bool isOpen)
        {
            this.IsOpen = isOpen;
        }
    }
    public class Child : Parent
    {
        public Child(bool isOpen) : base(isOpen)
        {
        }
    }
