    class MyClassB{
        //....
        public MyCLassB Clone()
        {
          var result = new MyClassB
          {
            Height = Height
          };
          result.paramClassA = new MyClassA();
          if (paramClassA != null)
          {
            result.paramClassA.Width = paramClassA.Width;
          }
        }
    }
