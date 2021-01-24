    public ICommand DeleteVendor
    {
        get
        {
            return new ActionCommand(p => HandleDeleteVendor(), p => SelectedVendor != null);
        }
    }
    
    private void HandleDeleteVendor()
    {
        MessageBoxResult confirmation = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
        if (confirmation != MessageBoxResult.Yes);
           return;
    
        if (SelectedVendor == null)
        {
            // IMO, it is better to handle this situation gracefully and show messageBox with a warning
            throw new Exception("No vendor was selected");
        }
    
        UnitOfWork.Vendors.Remove(SelectedVendor);
        UnitOfWork.Save();
    }
