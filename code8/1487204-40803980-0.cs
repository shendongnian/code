    private  Lazy<List<A>> _defA = new Lazy<List<A>>(() => new List<A>());
    public List<A> DefA
    {
        get 
        { 
            return _defA.Value; 
        }
    }
