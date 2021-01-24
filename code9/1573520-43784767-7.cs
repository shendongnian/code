    public Node GetAncestor(int generations)
    {
        if (generations == 0)
            return this;
        return Parent?.GetAncestor(generations - 1);
    }
    //Will retrieve grandFather
    var ancesstor = son.GetAncestor(2);
