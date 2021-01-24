    class Apple : IFruit {
        public void Accept(IFruitVisitor visitor) => visitor.Visit(this);
    }
    class Banana : IFruit {
        public void Accept(IFruitVisitor visitor) => visitor.Visit(this);
    }
