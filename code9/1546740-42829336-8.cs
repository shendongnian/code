    using System.Collections.ObjectModel;
    using System.ComponentModel;
    public class MyComplexComponent:Component
    {
        public MyComplexComponent()
        {
            MySampleClasses = new Collection<MySampleClass>();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<MySampleClass> MySampleClasses { get; set; }
    }
