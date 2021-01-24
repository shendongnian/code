    namespace SomeProject.MeetTheControllers.Test
    {
        using Microsoft.AspNetCore.Mvc;
    
        public class SomeController: Controller
        {
            public void Test(string name, string notname)
            {
                string username = name;
                string nan = notname;
            }
        }
    }
