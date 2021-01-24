    public class Square : Rectangle (here it dose not work when inherit)
    {
        public Square(Point position, int size) : base(position, size) 
        {
        }
    
        override public void Draw(Graphics r)  
        {
            r.DrawRectangle(pen, 300, 100, 50, 50);
        }
    
    }
