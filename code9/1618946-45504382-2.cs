    public void SelectExchangeProductExecute(object parameter)
    {
        // parameter will then be your Barcode
        if(parameter is string barcode)
        {
             // Now you have the barcode available... but you can really bind anything to end up here.
        }
    }
    public bool SelectExchangeProductCanExeucte(object parameter)
    {
         // return true and false accordingly to execution logic. By default, just return true...
        return true;
    }
