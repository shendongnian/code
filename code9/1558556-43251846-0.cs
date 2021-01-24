    public void DoSomethingWithCollecion()
    {
        var genericCol = col.OfType<I<Model>>();
        foreach (var a in genericCol )
        {
            //a.Results is now accessible.
        }
    }
