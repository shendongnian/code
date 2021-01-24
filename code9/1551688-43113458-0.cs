     public static void Main(String[] rags)
        {
            //If you are not sure about username and password, leave below 2 variables as it is
            String username="";        //Change to your username, if you have any
            String passwd="";           //Change to your Password, if you have any
            DirectoryEntry entry = new DirectoryEntry("LDAP://abcedf/OU=abcdef,DC=avengers,DC=net", username, passwd, AuthenticationTypes.None);           
            DirectorySearcher ds = new DirectorySearcher(entry,"ObjectClass=*");
           
            // Below statement will list all entries immediately below your BaseDN
            foreach (DirectoryEntry c in entry.Children)
            {
                Console.WriteLine("{0}", c.Path);
            }
         }
                
         
