    public List<X> GetXObjects(List<Y> yObjects)
    {
        var transformer = new Transformer();
        return transformer.Transform(yObjects);
    }
