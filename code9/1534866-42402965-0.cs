    public class vector
    {
        private int x;
        private int y;
        public vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static vector operator *(vector w1, vector w2)
        {
            return new vector(w1.x* w2.x, w1.y * w2.y);
        }
    }
