    try
    {
        var thisPath = Assembly.GetExecutingAssembly().Location;
        var stampData = StampReader.ReadStampFromFile(thisPath, StampConstants.StampSubject, StampConstants.StampOid);
        var stampText = Encoding.UTF8.GetString(stampData);
        lbStamped.Text = stampText;
    }
    catch (StampNotFoundException ex)
    {
        MessageBox.Show(this, $"Could not locate stamp\r\n\r\n{ex.Message}", Text);
    }
