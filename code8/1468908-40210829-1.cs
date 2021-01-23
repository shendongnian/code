    public class Form2 : Form
    {
       public int MyValue{get;set;}
    }
    
    public class Form1 : Form
    {
      private int _myValue;
      public int MyValue
      {
         set
         {
            if (_myValue != value)
            {
               form2.MyValue = value;
            }
         }
      }
    }
