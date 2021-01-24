    private void PreviewNumInput(object sender, TextCompositionEventArgs e)
    {
        if (!IsPositiveNum(hourBox.Text + e.Text))
            e.Handled = true;
    }
    private bool IsPositiveNum(string str)
    {
        int x;
        if (int.TryParse(str, out x) && x >= 0 && x <= 50)
            return true;
        return false;
    }
