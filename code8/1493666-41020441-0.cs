        public partial class A : System.Web.UI.UserControl
        {   
          public event EventHandler BindDataTotalSummary;
        
           public static void BindDataTotalSummary()
          {
             //Some Stuff of code
           }
        }
    
       public partial class B : System.Web.UI.UserControl
       { 
         public static void MethodB()
         {
            A.BindDataTotalSummary();
            //Some Stuff of code
         }
       }
