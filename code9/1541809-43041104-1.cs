    public void shoppingCartGridView_UpdateItem(int ItemDetailId)
       {
            try
            {
                int rowIndex = GetRowIndexByItemDetailId(ItemDetailId);
                TextBox quantityTextBox = (TextBox)ShoppingCartGridView.Rows[rowIndex].FindControl("quantityTextBox");
                int newQuantity = int.Parse(quantityTextBox.Text);
                UpdateCartItem(ItemDetailId, newQuantity);
                DisplayMessage("Your cart has been updated successfully", Bootstrap.MessageType.Success);
                ShoppingCartGridView.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, $"{this}");
                DisplayMessage(@"An error occured while updating your cart item, 
                                 please try again in a moment", Bootstrap.MessageType.Danger);
            }
        }
