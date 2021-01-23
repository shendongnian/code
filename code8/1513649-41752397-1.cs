    public bool InterNode(HtmlNode htmlNode, ref Paragraph originalPar)
    {
        string htmlNodeName = htmlNode.Name.ToLower();
    
        List<string> nodeAttList = new List<string>();
        HtmlNode parentNode = htmlNode.ParentNode;
        while (parentNode != null) {
            nodeAttList.Add(parentNode.Name);
            parentNode = parentNode.ParentNode;
        } //we need to get it multiple types, because it could be b(old) and i(talic) at the same time.
    
        Inline newRun = new Run();
        foreach (string noteAttStr in nodeAttList) //with this we can set all the attributes to the inline
        {
            switch (noteAttStr)
            {
                case ("b"):
                case ("strong"):
                    {
                        newRun.FontWeight = FontWeights.Bold;
                        break;
                    }
                case ("i"):
                case ("em"):
                    {
                        newRun.FontStyle = FontStyle.Italic;
                        break;
                    }
            }
        }
        
        if(htmlNodeName == "#text") //the #text means that its a text node. Like <i><#text/></i>. Thanks @HungCao
        {
            ((Run)newRun).Text = htmlNode.InnerText;
        } else //if it is not a #text, don't load its innertext, as it's another node and it will always have a #text node as a child (if it has any text)
        {
            foreach (HtmlNode childNode in htmlNode.ChildNodes)
            {
                InterNode(childNode, ref originalPar);
            }
        }
        return true;
    }
