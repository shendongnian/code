    int id;
    if(!Int32.TryParse(itemId.Text, out id))
    {
        MessageBox.Show("Invalid input for ID field! Please write a valid integer");
        return;
    }
    int price;
    if(!Int32.TryParse(itemPrice.Text, out price))
    {
        MessageBox.Show("Invalid input for the price field! Please write a valid integer");
        return;
    }
    .... and so on for all integer values
    itemsADE.EditItem(id,itemBarcode.Text, itemName.Text, itemGroup.Text, 
                      itemCompany.Text, itemPlace.Text, 
                      price, ......);
