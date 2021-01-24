        public class Ball
        {
            public static List<Ball> balls = new List<Ball>();
            public int value { get; set; }
            public Boolean active { get; set; }
            public Ball() {}
            public Ball(int size)
            {
                // initial class
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    balls.Add(new Ball(){ value = rand.Next(), active = false}); 
                }
            }
            public Ball GetRandom()
            {
                Random rand = new Random();
                Ball randomBall = balls.Where(x => x.active == false).Select((x) => new { value = x, randX = rand.Next() }).OrderBy(x => x.randX).FirstOrDefault().value;
                randomBall.active = true;
                return randomBall;
            }
        }
