    namespace Root.Gui
    {
        using Root.Entities;
        public class Main
        {
            public Main()
            {
                // The following causes an error 
                // if Root.Security is add as a reference to the project.
                // even without adding `using Root.Security`
                var security = new Security();
            }
        }
    }
