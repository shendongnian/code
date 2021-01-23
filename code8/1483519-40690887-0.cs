    public class GenusAttribute : Attribute
    {
        public string GenusName {get; private set;}
    	public GenusAttribute(string genusName)
    	{
    	    GenusName = genusName;
    	}
    }
    
    [GenusAttribute("Catus")] // or simply [Genus("Catus")], no need to type 'Attribute' in here
    public class Cat : Animal
    {
    
    }
