    public class Client : MarshalByRefObject {
       public string GetResponse(string address) {
         // you can get crazy with ServicePointManager settings here
         // + actually do the request
       }
    }
    public sealed class Isolated<T> : IDisposable where T : MarshalByRefObject {
       private AppDomain _domain;
       public Isolated() {
         _domain = AppDomain.CreateDomain("Isolated:" + Guid.NewGuid(), null,
           AppDomain.CurrentDomain.SetupInformation);
         var type = typeof(T);
         Value = (T)_domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
       }
       public T Value { get; private set; }
       public void Dispose() {
         if (_domain == null) return;
         AppDomain.Unload(_domain);
        _domain = null;
       }
    }    
