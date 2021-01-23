    private RichTextBox ActiveRichTextBox
    {
        get
        {
            RichTextBox rtb = null; // initialising null
            TabPage tp = tabControl1.SelectedTab;
            if (tp!=null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }
            return rtb;
         }
     }
