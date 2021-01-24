    public class MyObject1 : IMyObject {
        ...
	    public IMyObject Clone() {
		    return (IMyObject)this.MemberwiseClone();
	    }
    }
    public class MyObject2 : IMyObject {
        ...
	    public IMyObject Clone() {
		    return (IMyObject)this.MemberwiseClone();
	    }
    }
