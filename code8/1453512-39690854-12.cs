    bool ok = true;
    ok = database.IsPasswordCorrect("fooBar");
    if(ok) ok = database.Method1();
    if(ok) ok = database.Method2();
    if(ok) ok = database.Method3();
    if(!ok)
       MessageBox.Show(database.LastErrorMessage);
    public class Database
    {
        public string LastErrorMessage { get; set; } 
        public bool Method1()
        {
            if(errorFound)  
            {
                 LastErrorMessage = "Error found in method1";
                 return false;
            }
            ....
            return true;
        }
    }
