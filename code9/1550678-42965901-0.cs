    if (dblQuantitySold >= 20)
    {
        dblAmountTotalDue -= dblQuantitySold * dblPrice * 0.10;
        MessageBox.Show("A 10% discount will be given because 20 or more has been sold.");
    }
    else if (dblQuantitySold >= 10)
    {
        dblAmountTotalDue -= dblQuantitySold * dblPrice * 0.05;
        MessageBox.Show("A 5% discount will be given because 10 or more has been sold.");
    }
