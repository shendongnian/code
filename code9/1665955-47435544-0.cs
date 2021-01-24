    private void lvwColumns_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
    {
       if (string.IsNullOrWhitespace(e.Label))
       {
             e.CancelEdit = true;
             MessageBox.Show ("Please enter a valid value.");
             return;
       }
    }
