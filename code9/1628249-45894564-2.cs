    using System;
    using System.Reflection;
    
    namespace WindowsFormsApplication2
    {
        interface ICustomInterface
        {
        }
    
        public class ArrayList : System.Collections.ArrayList
        {
            public override int Add(object value)
            {
                if (!(value is ICustomInterface))
                {
                    throw new ArgumentException("Only 'ICustomInterface' can be added.", "value");
                }
                return base.Add(value);
            }
        }
    
        public sealed class MyComboBox : System.Windows.Forms.ComboBox
        {
            public MyComboBox()
            {
                FieldInfo fieldInfo = typeof(System.Windows.Forms.ComboBox.ObjectCollection).GetField("innerList", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(this.Items, new ArrayList());
            }
    
            protected override void RefreshItems()
            {
                base.RefreshItems();
    
                FieldInfo fieldInfo = typeof(System.Windows.Forms.ComboBox.ObjectCollection).GetField("innerList", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(this.Items, new ArrayList());
            }
        }
    
    }
