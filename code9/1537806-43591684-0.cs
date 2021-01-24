    public string GetChangeHtml(string originalXML, string changedXML)
    {
        XmlDiffView view = new XmlDiffView();
        var diffgram = Diff(originalXML, changedXML);
        string ret = "";
        using (StringReader legacySr = new StringReader(originalXML), diffGramSr = new StringReader(diffgram.ToString()))
        {
            using (XmlReader legacyReader = XmlReader.Create(legacySr), diffgramReader = XmlReader.Create(diffGramSr))
            {
                using (StringWriter sw = new StringWriter())
                {
                    view.Load(legacyReader, diffgramReader);
                    view.GetHtml(sw);
                    ret = sw.ToString();
                }
            }
        }
        return ret;
    }
