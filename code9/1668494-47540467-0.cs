    public class Snake
    {
        public List<Rectangle> Parts { get; } = new List<Rectangle>();
        public void MoveX(int delta)
        {
            for(int i = 0; i < Parts.Count; i++)
            {
                // Read the current rectangle from the list
                var rect = Parts[i];
                // Change the coordinate.
                rect.X += delta;
                // Write the modified rectangle back into the list
                Parts[i] = rect;
            }
        }
        public void MoveY(int delta)
        {
            for(int i = 0; i < Parts.Count; i++)
            {
                // Read the current rectangle from the list
                var rect = Parts[i];
                // Change the coordinate.
                rect.Y += delta;
                // Write the modified rectangle back into the list
                Parts[i] = rect;
            }
        }
    }
