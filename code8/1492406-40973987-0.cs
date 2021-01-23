    internal static string GetQuery(this TextBox textBox)
    {
        if(string.IsNullOrEmpty(textBox.Text)) return string.Empty;
        return string.Format(textBox.Tag.ToString(), textBox.Text)
    }
    internal static string GetQuery(this ComboBox cmbBox)
    {
        if(cmbBox.SelectedIndex == -1) return string.Empty;
        return string.Format(cmbBox.Tag.ToString(), cmbBox.SelectedValue)
    }
