    var abc =  new ABC();
    var pqr = new PQR();
    pqr.MethodP += delegate { abc.MethodA(); };
    pqr.MethodQ += delegate { abc.MethodB(); };
    pqr.MethodR += delegate { abc.MethodC(); };
