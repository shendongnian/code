    MyClass hello = new MyClass(nameof(hello));
    class MyClass {
      private string Name;
      public MyClass(string name){ 
       this.Name = name; 
      }
      public string getName(){
        return this.Name;
     }
    }
