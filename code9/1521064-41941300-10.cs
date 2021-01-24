    namespace MyExtensionMethodNamespace
    {
        public class MyExtensionMethodClass
        {
            static public TextBox[] UpdateProperties(this TextBox[] textboxes)
            {
                foreach( var textBox in textBoxes)
                {
                    textBox.BackColor = Color.White;
                    textBox.MultiLine = true;
                }
                return textBoxes;
            }
            static public Control[] UpdateText(this Control[] controls)
            {
                foreach ( var control in controls)
                {
                    control.Text = "Test";
                }
                return controls;
            }
        }
    }
    //Main program
    using MyExtensionMethodNamespace;
    //Update three specific controls
    new [] {myControl1, myControl2, myControl3}.UpdateProperties().UpdateText();    
    //Update all controls on the form
    this.Controls.ToArray().UpdateProperties().UpdateText();
