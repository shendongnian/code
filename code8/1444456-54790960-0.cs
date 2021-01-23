public interface IGenericFactory
{
    IGeneric<T> GetGeneric<T>() where T : class;
}
public class GenericFactory: IGenericFactory
{
    private readonly IGeneric<int> intGeneric;
    private readonly IGeneric<string> stringGeneric;
    public GenericFactory(IGeneric<int> intG, IGeneric<string> stringG)
    {
        intGeneric = intG;
        stringG = stringG;
    }
    public IGeneric<T> GetGeneric<T>() where T : class
    {
        if (typeof(T) == typeof(IGeneric<int>))
            return (IGeneric<T>)Convert.ChangeType(intGeneric, typeof(IGeneric<T>));
        if (typeof(T) == typeof(IGeneric<string>))
            return (IGeneric<T>)Convert.ChangeType(stringGeneric,typeof(IGeneric<T>));
        else 
            throw new NotSupportedException();
    }
}
Please note i simply injected the two expected return types for clarity in the constructor.  I could have implemented the factory as a Dictionary and injected the return objects into this Dictionary.  Hope it helps. 
