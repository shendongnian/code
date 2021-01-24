    List<IWebElement> elements = new List<IWebElement>();
    AddElementsToList(elements, this.Driver.FindElements(By.Id("mm_date_8"));
    AddElementsToList(elements, this.Driver.FindElements(By.Id("dd_date_8"));
    // now in your calling method you can easily index list.
    return elements;
    
    public void AddElementsToList(List<IWebElement> elementList, IEnumberable<IWebElement> elementEnumerable)
    {
        if (elementEnumerable != null && elementEnumerable.Any())
        {
            elementList.AddRange(elementEnumerable);
        }
    }
