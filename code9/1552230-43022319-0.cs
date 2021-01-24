        public class MyClass
        {
            public void SomeMethod(System.Security.Principal.IPrincipal user)
            {
                //do something with 'user'
            }
        }
        
        public ActionResult SomeAction()
        {
            var myClass = new MyClass();
            myClass.SomeMethod(User);
        }
