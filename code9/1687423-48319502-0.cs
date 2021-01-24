    decimal actualAmount;
    if (myMoneyField != null)
    {
        actualAmount = myMoneyField.Value;
    }
    else 
    { 
        actualAmount = 0; 
    }
    Entity.Attributes.Add("budget_amount", new Money(actualAmount));
