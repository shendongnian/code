   	public class MyCSharpUtilities : CSharpUtilities
   	{
   		public override string Uniquifier(string proposedIdentifier, ICollection<string> existingIdentifiers)
   		{
   			var finalIdentifier = base.Uniquifier(proposedIdentifier, existingIdentifiers);
   
   			//Prefix entity names with underscore
   			if (finalIdentifier == "Food" ||
 				finalIdentifier == "Fruit" ||
   				finalIdentifier == "Vegetables")
    		{
    			finalIdentifier = "_" + finalIdentifier;
    		}
    
    		return finalIdentifier;
    	}
    }
