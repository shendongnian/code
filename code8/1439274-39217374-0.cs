    class ObjectA {
      public int Mode { get; set; }
    }
    class MainClass {
      private obj = new ObjectA();
      public int Mode {
        get { return this.obj.Mode; }
        set { this.obj.Mode = value; }
      }
    }
