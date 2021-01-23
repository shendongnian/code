    DateTime lastMovement;
    bool hidden = false;
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        webBrowser1.Document.MouseMove += Document_MouseMove;
    }
    void Document_MouseMove(object sender, HtmlElementEventArgs e)
    {
        lastMovement = DateTime.Now;
        if (hidden)
        {
            Cursor.Show();
            hidden = false;
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        TimeSpan elaped = DateTime.Now - lastMovement;
        if (elaped >= TimeSpan.FromSeconds(2) && !hidden)
        {
            Cursor.Hide();
            hidden = true;
        }
    }
