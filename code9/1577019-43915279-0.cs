    enum Wheels{
        twoWheeled,
        fourWheeled
    }
    
    class AnyClass
    {
    	public Wheels? Wheels{get;set;} //the question marks makes the property nullable
    }
	var a=  new AnyClass{Wheels = Wheels.twoWheeled};
	if(a.Wheels == null){} //unwheeled
	if(a.Wheels.HasValue){} //wheeled
	if(a.Wheels==Wheels.twoWheeled){} //direct check on specific type also works
