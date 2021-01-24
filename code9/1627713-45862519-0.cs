    public ElementObject() { }
        
    public static ElementObject Create(dynamic pSrcObj)
    {
        ElementObject obj = pSrcObj.ToObject<ElementObject>();
        obj.Init();
        return obj;
    }
        
    public void Init()
    {
        var _b = new string[] { nameof(ClassName), nameof(CssSelector), nameof(Id), nameof(LinkText), nameof(Name), nameof(PartialLinkText), nameof(TagName), nameof(XPath) };
        var _a = new string[] { ClassName, CssSelector, Id, LinkText, Name, PartialLinkText, TagName, XPath };
        
        index = Array.IndexOf(_a, _a.FirstOrDefault(s => !string.IsNullOrEmpty(s)));
        finalName = _a[index];
        finalClassName = _b[index];
    }
