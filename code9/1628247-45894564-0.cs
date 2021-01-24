    using System;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            interface ICustomInterface
            {
            }
    
            class MyClass : ICustomInterface
            {
            }
    
            class ArrayList : System.Collections.ArrayList
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
    
            public Form1()
            {
                InitializeComponent();
    
                FieldInfo fieldInfo = typeof(System.Windows.Forms.ComboBox.ObjectCollection).GetField("innerList", BindingFlags.NonPublic | BindingFlags.Instance);
                fieldInfo.SetValue(this.comboBox1.Items, new ArrayList());
    
                this.comboBox1.Items.Add(new MyClass());
                this.comboBox1.Items.Add(new MyClass());
    
                //Uncommenting following line will produce exception.
                //Because class 'string' does not implement ICustomInterface.
    
                //this.comboBox1.Items.Add("FFFFFF");
            }
        }
    
    
    }
