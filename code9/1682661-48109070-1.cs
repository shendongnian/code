    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    class CustomAttribute : Attribute 
    {
        public Type[] Included { get; set; }
        public Type[] Excluded { get; set; }
        
        // Keep a parameterless constructor to allow for
        // named attribute arguments
        public CustomAttribute()
        {
        }
        
        public CustomAttribute(Type[] included, Type[] excluded)
        {
            Included = included;
            Excluded = excluded;
        }
    }
    
    [CustomAttribute(new[] { typeof(string) }, new[] { typeof(int), typeof(bool) })]
    class Processor 
    {
        // Provide the named version still works
        [CustomAttribute(Included = new[] { typeof(string) },
                         Excluded = new[] { typeof(int), typeof(bool) })]
        public void Method()
        {
        }
    }
