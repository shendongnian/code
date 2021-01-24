    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication1
    {
        // Example custom control
        [Docking(System.Windows.Forms.DockingBehavior.Ask)]
        class MyControl : Control
        {
            public MyControl()
            {
                BackColor = Color.White;
            }
    
            // Example array property
            [Editor(typeof(NamesEditor), typeof(UITypeEditor))]
            public MyObject[] MyObjectArray
            {
                get;
                set;
            }
        }
    
        // This class requires System.Design assembly to be included in the project
        class NamesEditor : System.ComponentModel.Design.ArrayEditor
        {
            public NamesEditor(Type type)
                : base(type)
            {
            }
    
            protected override CollectionForm CreateCollectionForm()
            {
                Form form = base.CreateCollectionForm();
                form.Text = "Here you can put your User Friendly Display Text";
                return form as CollectionForm;
            }
        }
    
        // Example object
        public class MyObject
        {
            public string Text
            {
                get;
                set;
            }
        }
    }
