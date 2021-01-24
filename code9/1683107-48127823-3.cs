    interface IDrawable
    {
        void Draw();
        double ReturnArea(Func<double> del);
    }
    
    //...
    
    public double ReturnArea(Func<double> del)
    {
       return del();
    }
