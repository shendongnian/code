    public sealed class MyCustomAttribute : Attribute
    {
        public ushort Id { get; set; }
    
        public MyCustomAttribute(ushort id)
        {
            this.Id = id;
        }
    }
    public class MyDemoConsumer
    {
        public void MyConsumingMethod(ushort requiredTypeId)
        {
            var requestedType = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(type => type.GetCustomAttributes(typeof(MyCustomAttribute), false).Any())
                .Select(type => new { Type = type, CustomId = type.GetCustomAttributes(typeof(MyCustomAttribute), false).Cast<MyCustomAttribute>().Single().Id })
                .Where(item => item.CustomId == requiredTypeId)
                .Select(item => item.Type)
                .SingleOrDefault();
    
            if (requestedType != null)
            {
                var result = Activator.CreateInstance(requestedType);
            }
        }
    }
