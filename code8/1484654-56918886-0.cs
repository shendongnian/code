    public class CustomEFUtilities : CSharpUtilities
    {
        public override string Uniquifier(
            string proposedIdentifier, ICollection<string> existingIdentifiers)
        {
            var finalIdentifier = base.Uniquifier(proposedIdentifier, existingIdentifiers);
            
            // your changes here
            if (finalIdentifier.StartsWith("tl"))
            {
                finalIdentifier = finalIdentifier.Substring(2);
            }
            
            return finalIdentifier;
        }
    }
