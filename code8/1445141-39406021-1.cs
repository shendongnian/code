    private void btnW_Click(object sender, EventArgs e)
    {
        Func<Control, TextBox> FindFocusedTextBox(Control control)
        {
            var container = this as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control as TextBox;
        }
        
        var focussedTextBox = FindFocusedTextBox(this);
        if(focussedTextBox != null)
            focussedTextBox.Text += btnW.Text;
    }
