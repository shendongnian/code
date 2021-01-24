    static class FormMethods
    {
        public static void label1_Click(object sender, EventArgs e)
        {
            Label label = (Label) sender;
            // Try to find the textbox through the label's parent form
            TextBox textBox = (TextBox) label.Parent.Controls.Find("textBox1", true).First();
            if (textBox != null)
            {
                textBox.Select();
            }
        }
    }
