    abstract class Base {
        private void method1()
        {
            //Method 1
        }
        
        private void method2()
        {
            //Method 2
        }
    
        protected abstract void BetweenMethod1And2();
    
        public void RunTemplateMethod() {
            method1();
            BetweenMethod1And2();
            method2();
        }
    }
