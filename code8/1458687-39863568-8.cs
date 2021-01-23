    public class C1
    { 
        private string variable1;
        public C1(string VARIABLE1)
        {
            variable1 = VARIABLE1;
        }
        string C1Function()
        {
            if (variable1 == "value") 
                variable1 = somevalue;
            return variable1
        }
    }
    ///...
    class C2
    {
        void Page_Load(object sender, EventArgs e)
        {
            var C1TypeInstance = new C1(Session["VARIABLE1"]);
            Session["VARIABLE1"] = C1TypeInstance.C1Function();
        }
    }
    
