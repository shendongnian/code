    public class C1
    { 
        public string VARIABLE1 {get; set;}
    }
    ///...
    class C2
    {
        void Page_Load(object sender, EventArgs e)
        {
            Session["VARIABLE1"] = Session["VARIABLE1"] ?? new C1();
            ((C1)Session["VARIABLE1"]).VARIABLE1 = "somevalue";
        }
    }
