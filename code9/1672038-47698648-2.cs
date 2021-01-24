    public MyBinding(string path, string param) : base(path)
    {
        int x;
        double d;
        bool b;
        if (Int32.TryParse(param, out x))
        {
            //  ...
        }
        else if (Double.TryParse(param, out d))
        {
            //  ...
        }
        else if (Boolean.TryParse(param, out b))
        {
            //  ...
        }
    }
