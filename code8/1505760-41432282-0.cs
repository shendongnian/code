    private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
        //save item
        args.Cancel = await ValidateForm();
    }
    private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
    {
    }
    // Returns true if the MessageDialog was shown, otherwise false
    private async Task<bool> ValidateForm()
    {
        //Ensure all fields are filled
        String barcode = BarcodeText.Text.Trim();
        String desc = DescText.Text.Trim();
        String cost = CostText.Text.Trim();
        String price = PriceText.Text.Trim();
        String stock = StockText.Text.Trim();
        if(barcode.Equals(String.Empty) || desc.Equals(String.Empty) ||
                desc.Equals(String.Empty) || cost.Equals(String.Empty) || 
                price.Equals(String.Empty) || stock.Equals(String.Empty))
        {
            var dialog = new MessageDialog("Please fill in all fields");
            await dialog.ShowAsync();
            return true;
        }
        //check uniqueness of the barcode
        return false;
    }
