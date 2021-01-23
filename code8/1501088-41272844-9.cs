    using AttributesNamespace;
    using static ExtensionsNamespace.Extensions;
    
    namespace Myproject
    {
        class MyClass
        {
            public static void Main()
            {
                var info = GetAttribute<DisplayAttribute>(LeadStatus.Created);
                var name = info.Name;
                var bg = info.BackgroundColor;
            }
        }
    
        public enum LeadStatus : byte
        {
            [Display(Name = "Created", BackgroundColor = "Red")] Created = 1,
            [Display(Name = "Assigned")] Assigned = 2,
        }
    }
