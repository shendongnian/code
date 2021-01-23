    DateTime? lastMovement;
    bool hidden = false;
    void Form1_Load(object sender, EventArgs e)
    {
        webBrowser1.Navigate("http://www.google.com");
    }
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
        if (!lastMovement.HasValue)
            return;
        TimeSpan elaped = DateTime.Now - lastMovement.Value;
        if (elaped >= TimeSpan.FromSeconds(2) && !hidden)
        {
            Cursor.Hide();
            hidden = true;
        }
    }
