    var productTitles = SeleniumContext.Driver.FindElements(By.XPath(ComparisonTableElements.ProductTitle))
    
    for ( int i = 0; i < productionTitles.Length; i++ )
    {
        var currentObject = productionTitles[i];
        for ( int j = i + 1; j < productionTitles.Length; j++ )
        {
            if ( currentObject.Title == productionTitles[j].Title )
            {
                // here's your duplicate
            }
        }
    }
