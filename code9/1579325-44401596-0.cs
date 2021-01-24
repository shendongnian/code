    public void test(){
       DateTime ParsedDate;
       string SomeDate = "12-May-2017";
       if(parseDate(SomeDate, out ParsedDate))
       {
           // Date was parsed successfully, you can now used ParsedDate, e.g.
           Customer.Orders[0].DateRequired = ParsedDate;
       }
       else
       {
        // Throw an error
       }
    }
