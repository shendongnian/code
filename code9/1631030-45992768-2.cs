    public class MyPasswordConverter: ITypeConverter<string, SecureString>
    {
        public SecureString Convert(string source, SecureString destination, ResolutionContext context)
        {
            return StringUtils.Encrypt(source);
        }
    }
