    var listOfAllControls = Controls.Cast<Control>();
    var listOfTextBoxes= listOfAllControls.Where(control =>control.GetType()==typeof(TextBox));
    TextBox emptyTextBox = (TextBox)listOfTextBoxes.FirstOrDefault(textbox => String.IsNullOrEmpty(textbox.Text));
    if (emptyTextBox != null)
    emptyTextBox.Text = CaptchaWeb.Document.GetElementById("gcaptcha").GetAttribute("value");
