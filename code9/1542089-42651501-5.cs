    ICart cart = new Guest();
    ICart cart2 = new Member();
    if (cart is Guest)
    {
       bool info=((Guest)cart).IsInfoExist;
    }
   
    if (cart is Member)
    {
       bool info=((Member)cart).IsInfoExist; //this won't compile as IsInfoExist is not in the Member class
    }
