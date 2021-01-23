    public static string GetType(Pizza pizza)
    {
        switch (pizza)
        {
            case Pizza.Peeporoni:
                return Pizza.Peeporoni.ToString();
            case Pizza.Maxican:
                return Pizza.Maxican.ToString();
            case Pizza.Cheese:
                return Pizza.Cheese.ToString();    
            default:
                return "";
        }
    }
