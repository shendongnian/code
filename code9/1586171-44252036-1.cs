    public class ParentClass {
        
        protected readonly Int32 x;
        public ParentClass() {
            this.x = 123;
        }
    }
    public class Subclass : ParentClass {
        
        // Using your proposed idea:
        public Subclass() {
            
            Int32 localX = base.x; // get the current value of `ParentClass.x`
            base(); // call base constructor
        }
    }
