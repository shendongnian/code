    IEnumerator<string> proxies;
    IEnumerator<string> websites;
    private void button1_Click(object sender, EventArgs e)
    {
        List<string> strings = new List<string>();
        strings = textBox2.Text.Split('\n').ToList();
        proxies = strings.GetEnumerator();
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        // Stop the first timer until the second one completes
        timer1.Enabled = false;
        WinInetInterop.SetConnectionProxy(proxies.Current);
        label1.Text = proxies.Current;
        List<string> stringsweb = textBox1.Text.Split('\n').ToList();
        websites = stringsweb.GetEnumerator();
        timer2.Enabled = true;
    }
    private void timer2_Tick(object sender, EventArgs e)
    {
        webBrowser1.Navigate(websites.Current);
        label2.Text = websites.Current;
        // Let's continue with the second timer until completition
        timer2.Enabled = websites.MoveNext();
        // Reenable the first when the second timer completes
        if(!timer2.Enabled) 
            timer1.Enabled = strings.MoveNext();
    }
