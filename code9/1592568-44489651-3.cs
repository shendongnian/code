    public Triangle(string name, double side, double height)
    {
        Name = name; // note this
        if (side >= 0 && height >= 0)
        {
            this.side = side;
            this.height = height;
        }
        else
        {
            throw new Exception("Critical error: Value cannot be negative");
        }
    }
