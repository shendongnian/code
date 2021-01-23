    var paymentObjectList = new List<PaymentObject>();
    // assuming the above gets populated at some point 
 
    object[,] dataArray = new object[paymentObjectList.Count, 2];
    int listIndex = 0;
    foreach (var paymentObject in paymentObjectList)
    {
        dataArray[listIndex, 0] = paymentObject.PaymentDate;
        dataArray[listIndex, 1] = paymentObject.Amount;
        listIndex++;
    }
    // resuming your original code
    s.Data = new Data(dataArray);
