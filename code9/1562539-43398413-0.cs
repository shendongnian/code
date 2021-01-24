    private bool m_bInTextChanged;
    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (m_bInTextChanged)
            return;
        m_bInTextChanged = true;
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            //save caretIndex
            int caretIndex = tb.CaretIndex;
            if (e.Changes.Any())
            {
                var additions = e.Changes.Where(tc => tc.AddedLength > 0);
                foreach (var added in additions)
                {
                    string stringchanged = tb.Text.Substring(added.Offset, added.AddedLength);
                    tb.Select(added.Offset, added.AddedLength);
                    tb.SelectedText = stringchanged.ToLower();
                }
            }
            //restore caretIndex
            tb.CaretIndex = caretIndex;
         }
        m_bInTextChanged = false;
     }
