    foreach (var section in html.DocumentNode.SelectNodes("//p[@class='section']"))
    {
        Console.WriteLine(section.InnerText);
        foreach (var subSection in section?.SelectNodes("following-sibling::p")
                                          ?.TakeWhile(n => n?.Attributes["class"]?.Value != "section")
                                          ?? Enumerable.Empty<HtmlNode>())
            Console.WriteLine("\t" + subSection.InnerText);
    }
    /*
    sectiontext1
            subtext1-1
            subtext1-2
    sectiontext2
            subtext2-11
            subtext2-22
    sectiontext3
    */
