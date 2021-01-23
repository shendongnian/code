	public void Initialize(){
		Console.WriteLine("Consumable.Initialize()");
    	quantity = 1;
	}
	public  void Initialize(int Quantity){
      Console.WriteLine("Consumable.Initialize(QTY)");
		
  	  if (quantity <= maxStack)
    	    quantity = Quantity;
       else
     	   quantity = maxStack;
	 }
