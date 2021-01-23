    private void GroupBox1_Validating(object sender, CancelEventArgs e)
    {
        base.OnValidating(e);
        var selectedIndices = groupBox1.Controls.OfType<ComboBox>().Select(item => item.SelectedIndex);
        var anyDuplicates = selectedIndices.GroupBy(x => x).Any(x => x.Count() > 1);
        if (!anyDuplicates)
            return;
        MessageBox.Show("There are duplicates!");
        e.Cancel = true;
    }
