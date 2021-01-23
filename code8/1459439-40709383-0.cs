    public class Movement 
    {
        // define a movement interval and store the elapsed time between moves
        private double interval, elapsedTime;
        public Movement(double interval) 
        {
            this.interval = interval;
        }
        // called when arrow keys are pressed (player)
        public void Move(Direction dir) 
        {
            if(elapsedTime > interval)
            {
                // move
            }
        }
        // called once per frame from the main class Update method
        public void Update(GameTime gameTime)
        {
            if(elapsedTime > interval)
                elapsedTime -= interval;
            // add milliseconds elapsed during the frame to elapsedTime
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds; 
        }
    }
    public enum Direction 
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
