    public class ChunkArray<T>
    {
        private const int DefaultSideDivision = 16;
    
        T[][] internalData;
    
        int xChunks;
        int yChunks;
    
        int subWidth;
        int subHeight;
    
        public int w;
        public int h;
    
        public ChunkArray(int width, int height)
        {
            int sideDivision = DefaultSideDivision;
            w = width;
            h = height;
            subWidth = width / sideDivision;
            subHeight = height / sideDivision;
    
            int widthRemainder = width % sideDivision;
            int heightRemainder = height % sideDivision;
    
            xChunks = (widthRemainder == 0) ? sideDivision : sideDivision + 1;
            yChunks = (heightRemainder == 0) ? sideDivision : sideDivision + 1;
    
            internalData = new T[xChunks * yChunks][];
    
            for (int i = 0; i < xChunks; i++)
            {
                for (int j = 0; j < yChunks; j++)
                {
                    internalData[GetFirstIndex(i,j)] = new T[subWidth * subHeight];
                }
            }
        }
    
        private int GetFirstIndex(int i, int j)
        {
            return i + j * xChunks;
        }
    
        private int GetSecondIndex(int i, int j)
        {
            return i + j * subWidth;
        }
    
        public T get(int x, int y)
        {
            return internalData[GetFirstIndex(x / subWidth, y / subHeight)][GetSecondIndex(x % subWidth, y % subHeight)];
        }
    
        public void set(int x, int y, T value)
        {
            internalData[GetFirstIndex(x / subWidth, y / subHeight)][GetSecondIndex(x % subWidth, y % subHeight)] = value;
        }
    }
