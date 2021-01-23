    interface StaticWrapper
    {
        InPtr WrapStaticMethod(string name, string windowName);
    }
    class MyUsualBehaviour : IStaticWrapper
    {
        public InPtr WrapStatic(string name, string windowName)
        {
            // here we do the static call from extern DLL
            return FindWindow(name, widnowName);
        }
    }
