    class A {
       public ICanBeUsedOnlyByA A { get; set; }
        public A (ICanBeUsedOnlyByA a){
           A = a;
        }
    }
    
    class B {
       public ICanBeUsedOnlyByA B { get; set; }
        public B (ICanBeUsedOnlyByB b){
           B = b;
        }
    }
