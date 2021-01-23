    public class PieRepositoryException : Exception
    {   
        public PieRepositoryException(string message, Exception innerException, params string[] ingredients):base(message, innerException)
        {
            Ingredients = ingredients;
        }
        
        public property string[] Ingredients { get; private set; }
    }
