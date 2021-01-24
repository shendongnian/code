    //Modify IMessage
    public abstract class IMessage
    {
        public abstract byte Id{ get; }
    }
    //Add the property to your messages
    public class MessageOne : IMessage
    {
        public override byte Id{ get{ return 0; } }
    }
    //Create a Init method
    void Init()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(IMessage)));
        MethodInfo method = typeof(this).GetMethod("CreateConverter");
        foreach (var type in types)
        {
            var instance = (IMessage)Activator.CreateInstance(type);
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            genericMethod.Invoke(this, instance.Id);
        }
    }
    //Now you only need to do at the begining of your code...
    Init();
