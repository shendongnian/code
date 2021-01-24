    var elements = driver.FindElements(By.CssSelector("ul.list-inline > li > a"));
    // Here you can iterate though links and do whatever you want with them
    foreach (var element in elements)
    {
    	Console.WriteLine(element.Text);
    }
    
    // Here is the collection of links texts
    var linkNames = elements.Select(e => e.Text).ToList();
