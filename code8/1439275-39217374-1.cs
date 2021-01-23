    class ObjectA {
      private int mode;
      public ObjectA(int mode) {
        this.mode = mode;
      }
      // you can create property instead of method
      // I'm not sure how you use this variable, so I just added set method
      public void SetMode(int mode) {
        this.mode = mode;
      }
    }
    class MainClass {
      private int mode = 0;
      private obj = new ObjectA();
      public int Mode {
        get { return this.mode; }
        set {
          this.obj.SetMode(value);
          this.mode = value; 
        }
      }
    }
