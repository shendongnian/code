    private class abc // private class it
       {
           void abc()
           {
           }
           public  void show()
           {
               string abc = "";
           }
       }
     
       sealed class efg // Sealed class it
       {
           void efg()
           {
           }
           public void showefg()
           {
               string abc = "";
           }
       }
     
       public class cde : abc // in this class we inherit private class abc
       {
           void cde()
           {
               show(); // private class method show
           }
       }
     
       public class ghi : efg // we cannot inherit sealed class and it method
       {
           void ghi()
           {
               // not showing sealed class method  showefg() even it is public
           }
       }
     
    
    protected void Page_Load(object sender, EventArgs e)
        {
            cde c = new cde();// calling private class method by inheritance
            c.show();
       }
