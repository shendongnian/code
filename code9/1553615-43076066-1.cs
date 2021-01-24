    private void TxtOnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {       
        TextBox txt = (TextBox)sender;
        if (e.KeyCode == Keys.Home)
        {
            int idx = txt.SelectionStart;
            txt.SelectionStart = 0;
            txt.SelectionLength = e.Shift ? idx : 0;
        }
        else if (e.KeyCode == Keys.End)
        {
            int idx = txt.SelectionStart;
            if (e.Shift)
                txt.SelectionLength = txt.TextLength - idx;
            else
            {
                txt.SelectionStart = txt.TextLength;
                txt.SelectionLength = 0;
            }
        }
<!---->
        else if (e.KeyCode == Keys.Left)
        {
            if (e.Shift)
            {
                if (txt.SelectionStart > 0)
                {
                    txt.SelectionStart--;
                    txt.SelectionLength++;
                }
            }
            else
            {
                txt.SelectionStart = Math.Max(0, txt.SelectionStart - 1);
                txt.SelectionLength = 0;
            }
        }
        else if (e.KeyCode == Keys.Right)
        {
            if (e.Shift)
                txt.SelectionLength++;
            else
            {
                txt.SelectionStart = Math.Min(txt.TextLength, txt.SelectionStart + 1);
                txt.SelectionLength = 0;
            }
        }
    }
