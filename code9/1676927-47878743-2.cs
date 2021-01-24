    foreach(var item in DbResults.GroupBy(a => new 
    { 
        a.Case_Number, 
        a.Docket, 
        a.Agency_Name, 
        a.Report_Number}).Select(b => b.FirstOrDefault()))       
    {
    /* Fill the cells using EPPLUS to appropriate row and then do second 
    foreach to go through the Payee and amounts*/
        foreach(var paystuff in DbResults.Where(a => 
        a.Case_Number == item.Case_Number 
        && a.Docket == item.Docket
        && a.Agency_Name == item.Agency_Name
        && a.Report_Number == item.Report_Number)
        {
            // Fill the payment detail cells and increment the row counter
        }
    }
