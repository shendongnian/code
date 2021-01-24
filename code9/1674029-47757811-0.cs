    abstract class MyBase {
        protected abstract void CustomLogic(); // Subclasses implement this
        public void PayloadMethod() {
            ... // Do somethig
            CustomLogic();
            ... // Do something else
        }
    }
    class Derived1 : MyBase {
        protected override void CustomLogic() {
            ... // Custom logic 1
        }
    }
    
    class Derived2 : MyBase {
        protected override void CustomLogic() {
            ... // Custom logic 2
        }
    }
    
    class Derived3 : MyBase {
        protected override void CustomLogic() {
            ... // Custom logic 3
        }
    }
