    private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Quantity":
            case "ItemPrice":
                PropertyChanged(this, "TotalPrice");
                break;
        }
    }
