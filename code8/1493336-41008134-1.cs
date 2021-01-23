    public class Butter : Product { }
    public class Egg : Product { }
    public class Product { }
    
    public T AddGeneric<T>(T item) where T : Product
    {
    	//Do something
    	return item;
    }
    
    public Product Add(Product item)
    {
    	//Do something
    	
    	return item;
    }
    //Even though we know it's going to return an Egg, we still need to cast here
    //If we want to treat t as an Egg, rather than as a Product
	Product t = Add(new Egg());
    //No cast needed
	Egg tt = AddGeneric(new Egg());
