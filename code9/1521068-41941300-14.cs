    namespace MyExtensionMethodNamespace
    {
        public class MyExtensionMethodClass
        {
            static public TextBox UpdateProperties(this TextBox textbox)
            {
                textBox.BackColor = Color.White;
                textBox.MultiLine = true;
                return textBox;
            }
            static public Control UpdateText(this Control control)
            {
                control.Text = "Test";
                return control;
            }
        }
    }
    //Main program
    using MyExtensionMethodNamespace;
    this.PTextBox.UpdateProperties().UpdateText();
