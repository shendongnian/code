    public static class General {
        public static void CheckSecurity(System.Windows.Forms.Form frm) {
            // Does Security Check on frm
            frm.GetType(); // check the type here
        }
    }
    
    public class MyProjectBase : System.Windows.Forms.Form {
        public MyProjectBase() {
            General.CheckSecurity(this);
        }
    }
    
    public class ChildA : MyProjectBase {
        /*
           You don't have to add your own constructor. By default
           MyProjectBase class constructor is called every time you create
           new instance of ChildA.
    
           And in MyProjectBase constructor you have `this` of the origin object, 
           so it has the right type `ChildA` for objects of type ChildA.
        */
    
    
        // I need this class instance to call the General.CheckSecurity() function
        // but pass its own ChildA instance to that function automatically, without
        // even writing constructor of ChildA class
    }
