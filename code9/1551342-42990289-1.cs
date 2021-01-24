    private void deleteFromListToolStripMenuItem_Click(object sender, EventArgs e)
    {
        label4.Text = " ";
        textBox3.Text = "";
        IDocument document = textEditorControl1.Document;
        document.Remove(0, document.TextLength);
        textEditorControl1.Refresh();
        for (int i = listBox3.SelectedIndices.Count - 1; i >= 0; i--)
        {
            selectedScripts.RemoveAt(listBox3.SelectedIndices[i]);
            listBox3.Items.RemoveAt(listBox3.SelectedIndices[i]);
        }
    }
