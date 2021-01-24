    public DownloadAttachmentsHandler(BasePageElementMap basePageElementMap)
    {
        Type type = basePageElementMap.GetType();
        dynamic foo = Cast(basePageElementMap, type);
        UseDynamic(foo);
    }
