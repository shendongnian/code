    var orderItems = order.OrderItems;
    var lines = new List<Line>();
    foreach (var orderItem in orderItems) {
        //Line
        Line invoiceLine = new Line();
    
        //...code removed for brevity
    
        lines.Add(invoiceLine);
    }    
    //Assign Line Items to Invoice
    invoice.Line = lines.ToArray();
