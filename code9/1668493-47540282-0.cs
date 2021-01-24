    public class BodyPart
    {
        private Rectangle rectangle;
        public BodyPart(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }
        public void MoveY(int value)
        {
            rectangle.Y += value;
        }
        public void MoveX(int value)
        {
            rectangle.X += value;
        }
    }
    public class Snake
    {
        public List<BodyPart> Parts = new List<BodyPart>();
    }
    public class AppSnake
    {
        public void Run()
        {
            var snake = new Snake();
            snake.Parts.Add(new BodyPart(new Rectangle(760, 25, 8, 8)));
            snake.Parts[0].MoveY(-10);
        }
    }
