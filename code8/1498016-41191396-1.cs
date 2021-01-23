    private void Tb_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = sender as TextBox;
        ulong value;
        string text = tb.Text.Replace(",", "");
        string old = tb.Text;
        if (ulong.TryParse(text, out value))
        {
            int start = tb.SelectionStart;
            tb.Text = string.Format("{0:n0}", value);
            tb.SelectionStart = Math.Max(0, start + tb.Text.Length - old.Length);
            if (tb.SelectionStart > 0 && tb.Text[tb.SelectionStart - 1] == ',')
            {
                tb.SelectionStart--;
            }
        }
    }
