    [ServiceContract]
    public interface ILogging
    {
        [OperationContract]
        [ServiceKnownType("GetKnownTypes", typeof(KnownTypeHelper))] // << -- change this
        void LogException(ErrorExceptionInformation exception);
    }
    static class KnownTypeHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            System.Collections.Generic.List<System.Type> knownTypes =
                new System.Collections.Generic.List<System.Type>();
            knownTypes.Add(typeof(ErrorExceptionInformation));
           // knownTypes.Add(typeof(... any others....));
            return knownTypes;
        }
    }
