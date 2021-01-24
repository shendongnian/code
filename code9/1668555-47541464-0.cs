    private ShoppingItem ReadInput()
    {
        ShoppingItem item = new ShoppingItem();
    
        // a whitespace filled property should be invalid too in my opinion
        if (String.IsNullOrWhiteSpace(txtDescription.Text))
            return null;
        item.Description = txtDescription.Text; // Maybe apply some special formatting...
        if (String.IsNullOrWhiteSpace(txtAmount.Text))
            return null;
        item.Amount= txtAmount.Text; // Maybe apply some special formatting or a type conversion...
        // and so on...
        return item;
    }
