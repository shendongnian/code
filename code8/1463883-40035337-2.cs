    public static Pizza GetType(string pizza)
    {
        switch (pizza)
        {
            case "Peeporoni":
                return Pizza.Peeporoni;
            case "Cheese":
                return Pizza.Cheese;
            default:
                return Pizza.Maxican;
        }
    }
