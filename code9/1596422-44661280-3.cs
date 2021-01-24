    // Abstract class
    public abstract class Control : IGrid
    {
        // Property that is not overridden but is shared
        public int Number { get; set; }
        public abstract string Text
        {
            get;
        }
        public abstract void Click();
    }
    public class SelectList : Control
    {
        // Don't need the Number property here, base class has it
        public override string Text
        {
            get
            {
                return "Hello Select!";
            }
        }
        public override void Click()
        {
            Console.WriteLine("In the Select!");
        }
    }
    // Need everything in this class, but if it is all different anyways
    //  then base class is kind of a waste
    public class TextField : IGrid
    {
        public int Number { get; set; }
        public string Text
        {
            get
            {
                return "Hello TextField!";
            }
        }
        public void Click()
        {
            Console.WriteLine("In the TextField!");
        }
    }
