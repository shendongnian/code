    var cartItem= new Cart{id=id}; //Create an instance of your entity setting the key
    context.Carts.Attach(cartItem);// Attach the entity to the context
    cartItem.Quantity = quantity; //Set the property
    //If you haven't disabled change tracking or proxy creation, then you don't need to change the State, EF will do it.
    context.Entry(cartItem).State = EntityState.Modified;
    
    context.SaveChanges();
