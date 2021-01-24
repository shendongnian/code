    namespace ConslApp
    {
        class Prog
        {
            static void Main(string[] args)
            {
                using (var web = new Web())
                {
                    var myDll = Assembly.Load(web.DownloadData("http://localhost:8080/test-dll/bin/myDll.dll"));
                    Type t = myDll .GetType("ConslApp.Test");
                   // Instantiate my class
                   object Obj = new object();
                   obj = Activator.CreateInstance(t);
               }
           }
       }
    }
