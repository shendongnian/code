    class Customer
    {
       public Client Client
       {
           get
           {
               return this.clientFactory.GetClient(this.ClientID);
           }
       }
    }
