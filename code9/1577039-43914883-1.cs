    All_Frames Frame = new All_Frames(width, height, 1234); // or whatever value you want for xyx
    public struct All_Frames
    {
        public int[,] Y;
    
        public int xyx;
        public All_Frames(int width, int height, int initXyx)
        {
            Y = new int[width, height];
            xyx = initXyx;
        }
    }
