    var txt = @"
    <span class='price'>
    <span  itemprop='offers' itemscope itemtype='http://schema.org/Offer'  class='current'>
            <span  itemprop='price'>8,160,000 ریال  </span>
        </span>
        <span class='price-last-update' original-title='تاریخ به روز رسانی'>1396/03/23  </span>
    </span>
    ";
    
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(txt);
    
    Console.WriteLine(doc.DocumentNode.SelectSingleNode("/span[@class='price']").InnerText);
    //  8,160,000 ریال   1396/03/23
    Console.WriteLine(doc.DocumentNode.SelectSingleNode("//span[@class='price']/span").InnerText);
    //  8,160,000 ریال
