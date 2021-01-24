    public static int Depth(this Person iPerson)
    {
        if (iPerson.Children == null || iPerson.Children.Count() == 0)
        {
            return 1;
        }
        else
        {
            return 1 + Children.Max( iChild => iChild.Depth() );
        }
    }
