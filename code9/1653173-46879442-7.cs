    public static void Main()
    {
        IDrawable borderlessRectangle = new Rectangle(null);
        IDrawable borderedRectangle = new Border(borderlessRectangle);
        borderlessRectangle.Draw();//gives a rectangle without a border
        borderedRectangle.Draw();//gives a rectangle with a border
    }
