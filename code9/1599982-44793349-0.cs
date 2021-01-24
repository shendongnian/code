    public interface IDynamicTypeFactory
    {
        object New(string t);
    }
    public class DynamicTypeFactory : IDynamicTypeFactory
    {
        object IDynamicTypeFactory.New(string t)
        {
            var asm = Assembly.GetEntryAssembly();
            var type = asm.GetType(t);
            return Activator.CreateInstance(type);
        }
    }
