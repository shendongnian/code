       private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        htmlCode = wb.Document;
        wb.Dispose();
        wholeText = getTexts();
        plainText = splitText();
        numberOfWords = plainText.Length;
        webLinks = getLinks();
        imageLinks = getImages();
        imageSizes = getImageSize();
        richTextBox1.Text = browser1.wholeText;
    }
