    bool isValid = string.IsNullOrEmpty(model.CreditCard) ^ string.IsNullOrEmpty(model.Billing);
    if (!isValid)
    {
                failures.Add(new FailedValidation(
                        "Billing",
                        "Billing definition incorrect."));
     }  
