    public class MyClass
    {
        public delegate void UpdateStringVar(string x);
        private UpdateStringVar usv;
        MyClass(UpdateStringVar v)
        {
            usv = v;
        } 
    
        void ContinuouslyRunningOperation()
        {
            string status = //get some string
            usv(status);
        }
    }
