    public interface IGenerateLicenseKeys
    {
        SomeType GenerateKeys();
    }
    public class LicenseKeyGenerator : IGenerateLicenseKeys
    {
        public SomeType GenerateKeys()
        {
            //Generate your keys or  pass through to the other component with the static method. 
            throw new NotImplementedException();                         
        }
    }
