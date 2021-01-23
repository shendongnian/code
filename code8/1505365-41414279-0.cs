    string CSV = "\"a,b\",\"c,d\",\"e\",\"f\",g,h,i";
    string[] fields;
    using (var sr = new System.IO.StringReader(CSV))  
    using (var tfp = new Microsoft.VisualBasic.FileIO.TextFieldParser(sr)) {
        tfp.SetDelimiters(",");
        fields = tfp.ReadFields();
    }
