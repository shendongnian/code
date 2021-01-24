    [XmlAnyElement(nameof(item))]
    public List<XElement> _item
    {
        get
        {
            return item.color.Select(i =>
                new XElement(nameof(item),
                    new XElement(nameof(item.name), item.name),
                    new XElement(nameof(i.itemColor), i.itemColor)
                )).ToList();
        }
    }
