    private static void LoadFile(string filename, RichTextBox richTextBox)
    {
        if (string.IsNullOrEmpty(filename))
        {
            throw new ArgumentNullException();
        }
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException();
        }
        // open the file for reading
        using (FileStream stream = File.OpenRead(filename))
        {
            // create a TextRange around the entire document
            TextRange documentTextRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            // sniff out what data format you've got
            string dataFormat = DataFormats.Text;
            string ext = System.IO.Path.GetExtension(filename);
            if (String.Compare(ext, ".xaml", true) == 0)
            {
                dataFormat = DataFormats.Xaml;
            }
            else if (String.Compare(ext, ".rtf", true) == 0)
            {
                dataFormat = DataFormats.Rtf;
            }
            documentTextRange.Load(stream, dataFormat);
        }
    }
    private static void SaveFile(string filename, RichTextBox richTextBox)
    {
        if (string.IsNullOrEmpty(filename))
        {
            throw new ArgumentNullException();
        }
        // open the file for reading
        using (FileStream stream = File.OpenWrite(filename))
        {
            // create a TextRange around the entire document
            TextRange documentTextRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            // sniff out what data format you've got
            string dataFormat = DataFormats.Text;
            string ext = System.IO.Path.GetExtension(filename);
            if (String.Compare(ext, ".xaml", true) == 0)
            {
                dataFormat = DataFormats.Xaml;
            }
            else if (String.Compare(ext, ".rtf", true) == 0)
            {
                dataFormat = DataFormats.Rtf;
            }
            documentTextRange.Save(stream, dataFormat);
        }
    }
