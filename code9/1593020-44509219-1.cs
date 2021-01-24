    
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    namespace StackOverflowAnswers.CustomControlDefaultText
    {
        class CustomTextBoxDesigner : ControlDesigner
        {
            public CustomTextBoxDesigner()
            {
            }
            public override void InitializeNewComponent(IDictionary defaultValues)
            {
                // Allow the base implementation to set default values,
                // which are provided by the designer.
                base.InitializeNewComponent(defaultValues);
                // Now that all the basic properties are set, we
                // do our one little step here. Component is a
                // property exposed by ControlDesigner and refers to
                // the current IComponent being designed.
                CustomTextBox myTextBox = Component as CustomTextBox;
                if(myTextBox != null)
                {
                    myTextBox.Text = myTextBox.Name;
                }
            }
        }
        // This attribute sets the designer for your derived version of TextBox
        [Designer(typeof(CustomTextBoxDesigner))]
        class CustomTextBox : TextBox
        {
            public CustomTextBox() : base()
            {
                ReadOnly = true;
                TabStop = false;
                BorderStyle = BorderStyle.None;
            }
        }
    }
