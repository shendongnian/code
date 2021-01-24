    public void FirstStep()
    {
        foreach (HtmlElement elem in GetElementByTagAndContent("a", "hey"))
        {
            elem.InnerText = "blabla";
        }
        foreach (HtmlElement elem in GetElementByTagAndContent("button", "clickMe"))
        {
            step = 1;
        }
    }
    public void SecondStep()
    {
        switch (elem.GetAttribute("name"))
        {
            case "A":
            case "B":        
            case "C":
            case "D":
                elem.Destroy();
                break;
        }
        step = 2;
    }
    public void ThirdStep()
    {
        foreach (HtmlElement elem in GetElementByTagAndContent("div", "ClickMeNow"))
        {
            elem.InnerHtml = "/Done";
            step = 3;
        }
        foreach (HtmlElement elem in GetElementByTagAndContent("a", "linkit"))
        {
            elem.getAttribute("href") = "www.google.com";
            step = 3;
        }
    }
    public void timer1_tick()
    {
        switch(step)
        {
            case 1:
                FirstStep();
                break;
             case 2:
                SecondStep();
                break;
            case 1:
                ThirdStep();
                break;
        }
    }
    public IEnumerable<HtmlElement> GetElementByTagAndContent(string tag, string content)
    {
        foreach (HtmlElement elem in browser.Document.GetElementsByTag(tag))
        {
            if (elem.InnerText == content)
                yield return elem
        }
    }
