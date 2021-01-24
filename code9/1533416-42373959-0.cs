    namespace myNameSpace
    {
        public partial class Test : Page
        {
              public int TotalMethods;
              public bool bVal;
             public clsTest myTest;
              protected void Page_Load(object sender, EventArgs e)
             {
                ....
             }
           ....
          ....
        }
        public class clsTest
        {
            public bool Errors;
    
            public string FirstName;
            public bool FirstNameErr;
    
            public string LastName;
            public bool LastNameErr;
         }
    }
