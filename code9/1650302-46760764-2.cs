    private static readonly Thing[] _things = new [] { thing1, thing2, thing3 };
    public void ProcessThing(Thing variable)
    {
        if (_things.Contains(variable))
        {
            // ...
        }
    }
