    namespace MyExtensionMethodNamespace
    {
        public class MyExtensionMethodClass
        {
            static public void UpdateProperties(this System.Windows.Forms.Controls.TextBox textbox)
            {
                textBox.BackColor = Color.White;
                textBox.MultiLine = true;
            }
            static public void UpdateText(this System.Windows.Forms.Controls.Control control)
            {
                control.Text = "Test";
            }
        }
    }
    //Main program
    using MyExtensionMethodNamespace;
    this.PTextBox.UpdateProperties();
    this.PTextBox.UpdateText();
