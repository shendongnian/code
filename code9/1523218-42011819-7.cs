    public class SuperClass 
    {
    }
    
    public interface IWhatever<out TAssociation>
    	where TAssociation : SuperClass
    {
    	TAssociation Association { get; }	
    }
    
    public class SomeImplementation<TAssociation> : IWhatever<TAssociation>
    	where TAssociation : SuperClass
    {
    		public TAssociation Association { get; set; }
    }
