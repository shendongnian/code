    // set in assembly info:
    [assembly: ExternTypeAttribute(typeof(System.Collections.Generic.List<int>))]
    [assembly: ExternTypeAttribute(typeof(System.Attribute))]
    [assembly: ExternTypeAttribute(typeof(System.Console))]
    [assembly: ExternTypeAttribute(typeof(System.DateTime))]
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class ExternTypeAttribute : Attribute
    {
        public ExternTypeAttribute(Type type)
        {
            ExternType = type;
        }
        public Type ExternType { get; }
    }
    var attrs1 = Assembly.GetExecutingAssembly().GetCustomAttributes<ExternTypeAttribute>().ToArray();
    var attrs2 = typeof(System.Collections.Generic.List<int>).GetCustomAttributes<ExternTypeAttribute>().ToArray();
    var attrs3 = typeof(System.Attribute).GetCustomAttributes<ExternTypeAttribute>().ToArray();
    var attrs4 = typeof(System.Console).GetCustomAttributes<ExternTypeAttribute>().ToArray();
    var attrs5 = typeof(System.DateTime).GetCustomAttributes<ExternTypeAttribute>().ToArray();
    Console.WriteLine("This assembly: {0}, attached to types: {1} {2} {3} {4}", attrs1.Length, attrs2.Length, attrs3.Length, attrs4.Length, attrs5.Length);
