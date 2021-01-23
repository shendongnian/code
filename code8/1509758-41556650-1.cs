    public class MyControl2 : ExistingControl {
    
        public MyControl2() {
            // Initialize
        }
    
        public void Method1() {
            // Code
        }
        public int SomeProp
        {
            get { return 3; }
            set { /* Do stuff (with value) */ }
        }
        // Overriding existing functions
        public override int SomeValue()
        {
            return 45;
        }
    
    }
