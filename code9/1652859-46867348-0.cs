    public class Rectangle : IShape
    {
        public virtual void Draw()
        {
            throw new NotImplementedException();
        } 
    }
    
    public class Square : Rectangle
    {
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
