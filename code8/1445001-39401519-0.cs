        DateTime Date { get; }
    }
    public List<T> GetResultsList<T>()
        where T : IHasDate
    {
        var list = new List<T>();
        //Fill list
        list.Sort((t1, t2) => t1.Date.CompareTo(t2.Date));
        Return t;
    }
