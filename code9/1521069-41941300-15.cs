    namespace MyExtensionMethodNamespace
    {
        public class MyExtensionMethodClass
        {
            static public IEnumerable<TextBox> UpdateProperties(this IEnumerable<TextBox> textboxes)
            {
                foreach( var textBox in textBoxes)
                {
                    textBox.BackColor = Color.White;
                    textBox.MultiLine = true;
                }
                return textBoxes;
            }
            static public IEnumerable<Control> UpdateText(this IEnumerable<Control> controls)
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
    this.Controls.UpdateProperties().UpdateText();
