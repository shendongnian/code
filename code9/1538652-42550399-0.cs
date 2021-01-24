    // Get the numberformat to use, use current culture, or your own format
    private readonly IFormatProvider myNumberFormat = CultureInfo.CurrentCulture.NumberFormat
    private void OperatorFinishedEditing(TextBox box)
    {
        // read the text and try to parse it to a double
        // accepting all common formats of real numbers in the current culture
        bool valueOk = true;
        double resultValue = 0;
        if (!String.IsNullOrEmpty(box.Text))
        {
           bool valueOk = Double.TryParse(box.Text, out resultValue);
        }
        
        if (valueOk)
        {
            box.Text = FormatResultValue(resultValue);
            ProcessValue(resultValue);
        }
        else
        {
            ShowInputProblem();
        }
    }
