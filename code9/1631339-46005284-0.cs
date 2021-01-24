    string url = @"http://www.baza-firm.com.pl/?vm=zabrze&pg=2&b_szukaj=szukaj";
    var doc1 = new HtmlAgilityPack.HtmlDocument();
    using (var client = new HttpClient())
    {
        var resp = await client.GetAsync(url);
        MessageBox.Show(resp.StatusCode.ToString());
        var html = await resp.Content.ReadAsStringAsync();
        doc1.LoadHtml(html);
    }
    MessageBox.Show(doc1.DocumentNode.OuterHtml.ToString());
    .....
    ......
