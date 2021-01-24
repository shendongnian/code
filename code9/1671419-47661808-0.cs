    for (int i = 0; i < xmlReader.AttributeCount; i++) //or i = xmlReader.AttributeCount - 1; i >= 0; i--
    {
        xmlReader.MoveToAttribute(i);
        //...
    }
