    class ClassA{
        public ClassA(string caller){
            // when this class is instantiated I want to know "who" is creating an instance of it?
            // In this case the answer should be 'ClassB'
            Console.WriteLine("Caller="+caller);
        }
    }
    
    class ClassB{
        public SomeFunc(){
            // Do some stuff 
            var a = new ClassA(nameof(ClassB));
        }
    }
