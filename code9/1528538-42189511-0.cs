    public IPerson RemoveMax(Func<IEnumerable<IPerson>, IPerson> maxFunction)
    {
        IPerson person = maxFunction(this);
        Remove(person);
        return maxFunction(this);
    }
    public void Remove(IPerson person)
    {
        //Person removal code...
    }
