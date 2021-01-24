    class Program
        {
           public static class MainMenu
            {
                public static string sqlid = null;
                public static string sqlpw = null;
            }
    
    //Now a function will update values of variables
    
            public void updateDetails()
            {
                MainMenu.sqlid = sqlusr.Text;
                MainMenu.sqlpw = sqlpwd.Text;
            }
    
    //Now if i need to use variable values
    
            static void Main(string[] args)
            {
                Program p = new Program();
                p.updateDetails();
    
                public string cn = "Initial Catalog=" + db + "; User ID=" + MainMenu.sqlid + "; Password=" + MainMenu.sqlpw + ";";
    
            }
    }
