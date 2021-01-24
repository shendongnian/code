    private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;
        public static int CalculateFrameRate()
        {
            label.Text = CalculateFrameRate().ToString();
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }
