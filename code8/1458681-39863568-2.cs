    void C1Function()
    {
        if (Session["VARIABLE1"] == "value") 
            Session["VARIABLE1"] = somevalue;
    }
    ///...
    class C2
    {
        void Page_Load(object sender, EventArgs e)
        {
            C1TypeInstance.C1Function();
        }
    }
