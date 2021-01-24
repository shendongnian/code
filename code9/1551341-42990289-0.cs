    private void deleteFromListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        label4.Text = " ";
        textBox3.Text = "";
        IDocument document = textEditorControl1.Document;
        document.Remove(0, document.TextLength);
        textEditorControl1.Refresh();
        var indices = listBox3.SelectedIndices.OrderByDescending(i => i);
        foreach (var index in indices)
        {
            listBox3.Items.RemoveAt(index);
            selectedScripts.RemoveAt(index);
        }
    }
