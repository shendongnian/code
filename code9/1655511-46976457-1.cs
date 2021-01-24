    public static HtmlAgilityPack.HtmlDocument GetPreview(HtmlAgilityPack.HtmlDocument orginal, int maxTextLength)
    {
        var docPreview = new HtmlAgilityPack.HtmlDocument();
        docPreview.DocumentNode.CopyFrom(orginal.DocumentNode, false); // documentation bug in HtmlAgilityPack, false means deep-copy
        string allText = docPreview.DocumentNode.InnerText;
        int remainingDelete = allText.Length - maxTextLength;
        if (remainingDelete <= 0)
            return docPreview;  // you are finished
        // select only text nodes
        HtmlNodeCollection allTextNodes = docPreview.DocumentNode.SelectNodes("//text()[normalize-space(.) != '']");
        // iterate text nodes backwards
        for (int i = allTextNodes.Count - 1; i >= 0; i--)
        {
            HtmlTextNode textNode = allTextNodes[i] as HtmlTextNode;
            if (textNode == null) continue;
            int length = remainingDelete >= textNode.Text.Length ? 0 : textNode.Text.Length - remainingDelete;
            int removeLetterCount = textNode.Text.Length - length;
            remainingDelete = remainingDelete - removeLetterCount;
            textNode.Text = textNode.Text.Substring(0, length);
            if (remainingDelete == 0)
                break;
        }
        return docPreview;
    }
