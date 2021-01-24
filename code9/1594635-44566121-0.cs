     public class MyClass{
        public virtual string MyMethod (string param1, Dictionary<string, string> param2){
          int i= MyCommonCode.MyCommonMethod();
          //I do whatever I like with i here
        }
    }
    
    public class MyClassExtension : MyClass{
        public string MyMethod (string param1, Dictionary<string, string> param2, SpecialOjb param3)
        {
          int i= MyCommonCode.MyCommonMethod();
          //I do whatever I like with i here
        }
    }
    public class MyCommonCode
    {
      public static int MyCommonMethod()
      {
        return 1;
      }
    }
