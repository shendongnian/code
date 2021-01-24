    private void OnVisualEditorDocumentNavigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
    {            
            VisualEditor.Document.ContextMenuShowing += this.OnDocumentContextMenuShowing;
            htmldoc = new HtmlDocument(VisualEditor.Document);
            //((IHTMLDocument2)VisualEditor.Document.DomDocument).designMode = "ON";
            SetStylesheet();
            SetInitialContent();
            VisualEditor.Document.Body.SetAttribute("contenteditable", "true");             
            VisualEditor.Document.Body.SetAttribute("spellcheck", "true");
            VisualEditor.Document.Focus();
    }
