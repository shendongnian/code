    class DoSomethingParameters
    {
        public DoSomethingParameters() { A = 12; B = 42; }
        public int A { get; set; }
        public int B { get; set; }
    }
    
    var parameters = new DoSomethingParameters();
    parameters.A = /* something */;
    
    if (/* some condition */ {
        parameters.B = 29;
    }
    
    DoSomething(parameters);
