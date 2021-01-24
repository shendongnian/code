    public interface ICart
    {
         void GetCart();
    }    
    class Guest:ICart
    {
        public bool IsInfoExist
        {
            get { return Session["guest_info"] != null; }
        }
        public void GetCart()
       {
       }
    }
    class Member:ICart
    { 
        public void GetCart()
        {
        }
    }
