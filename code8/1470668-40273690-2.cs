    class Animal {
        public virtual void bark (){ 
            Console.WriteLine("woohhoo");
        }
    }
    class dog : Animal {
        public override void bark() {
           Console.WriteLine("woof");
        }
    }
