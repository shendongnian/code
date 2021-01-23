    private bool ReadInput()
    {
        double curReading = 0;
        double prevReading = 0;
        double amount = 0;
        double unitNumber = 0;
        var validData = true;
        if (double.TryParse(tbReading.Text, out curReading))
        {
            CalcData.SetCurrentReading(curReading);
        }
        else
        {
            validData = false;
        }
        if (double.TryParse(tbPrevReading.Text, out prevReading))
        {
            CalcData.SetPrevReading(prevReading);
        }
        else
        {
            validData = false;
        }
        if (double.TryParse(tbAmount.Text, out amount))
        {
            CalcData.SetAmount(amount);
        }
        else
        {
            validData = false;
        }
        if (double.TryParse(tbUnitNumber.Text, out unitNumber))
        {
            CalcData.SetUnitNumber(unitNumber);
        }
        else
        {
            validData = false;
        }
        if(!validData)
        {
            //Show your dialog here
        }
        return false;
    }
