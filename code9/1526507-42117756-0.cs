    foreach (var t in Totals)
    {
        PaymentSubTotals subs = new PaymentSubTotals();
        subs.Type = t.PaymentType;
        subs.Amount = t.Amount;
        model.Subs.Add(subs); 
    }
