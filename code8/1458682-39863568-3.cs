    string C1Function(sting VARIABLE1)
    {
       if (VARIABLE1== "value")
          return somevalue;
       return VARIABLE1;
    }
    ///...
    class C2
    {
        void Page_Load(object sender, EventArgs e)
        {
            Session["VARIABLE1"] = C1TypeInstance.C1Function(Session["VARIABLE1"]);
        }
    }
