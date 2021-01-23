    class Animal {
        public void bark (){ 
            Console.WriteLine("woohhoo");
        }
    }
    class dog : Animal {
      public new void bark() {
         Console.WriteLine("woof");
      }
    }
    output
        woohhoo
        woof
