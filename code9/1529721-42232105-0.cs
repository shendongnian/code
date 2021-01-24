    int positiveHash(string param)
    {
        // Some statements here...
        // ...
        // Start a small scope
        {
            int i = param.GetHashCode();
            if (...)
                return ((i > 0) ? (i) : (-i) );
        }
        // Some more C# statements here.
        // i is out of scope here.
    }
