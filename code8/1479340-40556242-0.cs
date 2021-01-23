	public ActionResult EditCartItem(string id, int quantity, decimal price)
	{
		if (Session["cart"] != null)
		{
			var cartVMList = (List<CartVM>) Session["cart"];
			var itemToEdit = cartVMList.FirstOrDefault(cartVM => cartVM.Id == id);
			if(itemToEdit == null)
				return this.HttpNotFound();
			itemToEdit.Quantity = quantity;
			itemToEdit.Price = price;			
		}
	}
	public ActionResult RemoveFromCart(string id)
	{
		if (Session["cart"] != null)
		{
			var cartVMList = (List<CartVM>) Session["cart"];
			var itemToRemove = cartVMList.FirstOrDefault(cartVM => cartVM.Id == id);
			if(itemToRemove == null)
				return this.HttpNotFound();
			cartVMList.Remove(itemToRemove);
		}
	}
