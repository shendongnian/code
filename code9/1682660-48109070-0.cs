    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    class CustomAttribute : Attribute 
    {
        public Type[] Included { get; set; }
        public Type[] Excluded { get; set; }
    }
    
    [CustomAttribute(Included = new Type[] { typeof(string) },
                     Excluded = new Type[] { typeof(int), typeof(bool) })]
    class Processor 
    {
    }
