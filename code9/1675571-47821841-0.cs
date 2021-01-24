    // inherit from MarshalByRefObject to enable cross domain communication
    public class AppDomainProxy : MarshalByRefObject {
        public int InvokeMethod() {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(dir, "ClassLibrary.dll");
            var asm = Assembly.LoadFile(path);
            var type = asm.GetType("ClassLibrary.Foo");
            var instance = Activator.CreateInstance(type, new object[] { });
            var method = type.GetMethod("Bar");
            return (int) method.Invoke(instance, null);
        }
    }
