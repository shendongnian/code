    class MainClass {
        public string ComposedMethod(){
            //Base class processing...
            var retVal = someMethod();
            //Even more Base class processing...
            return retVal; 
        } 
        public virtual string someMethod(){ 
        } 
    } 
    
    class SubClass : MainClass { 
        public override string someMethod(){
            return this.GetType().ToString(); //Or whatever you need to do
        } 
    } 
