    var orderItems = order.OrderItems;
    var lineCount = orderItems.Count();
    //Creating Line array before
    invoice.Line = new Line[lineCount];   
    for (int index = 0; index < lineCount; index++) {
        //Order item
        var orderItem = orderItems[index];
        //Line
        Line invoiceLine = new Line();
    
        //...code removed for brevity
    
        //Assign Line Item to Invoice
        invoice.Line[index] = invoiceLine;
    }   
    
