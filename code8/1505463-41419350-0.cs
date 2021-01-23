    public class Shareable
    {
    
    }
    public class Form1
    {
        public Shareable Shareable { get; set; }
    }
    
    public class Form2
    {
        public Form2()
        {
            // Now in this clas you can access the item to be shared
            Form1 frm = new Form1();
            var sharedItem = frm.Shareable;
        }
    }
