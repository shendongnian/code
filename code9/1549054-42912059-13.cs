    public void AdjustPayForHours (Pay payToAdjust)
    {
        // If someone worked for less than half an hour their rate of pay should be reduced in half
        if (payToAdjust.HoursWorked < 0.5) {
            payToAdjust.RateOfPay = payToAdjust.RateOfPay * 5.0
        }
    }
