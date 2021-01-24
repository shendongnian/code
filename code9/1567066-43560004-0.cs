    public static void AppendHTMLText(this RichTextBoxEx box, string html)
    {
        // use HtmlAgilityPack here
        // ...
        string text = doc.InnerText;
        if (box.InvokeRequired)
        {
            box.Invoke((MethodInvoker)delegate()
            {
                box.AppendText(text);
            });
        }
        else
        {
            box.AppendText(text);
        }
    }
