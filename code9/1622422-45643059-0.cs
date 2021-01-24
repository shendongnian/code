    public class Levels
    {    
        public string LevelName { get; private set; }
        public int LevelSize { get; private set; }
        public int LevelNum { get; private set; }
        // new level constructor. Takes name, size (to square) and level number.
        public Levels(string inName, int inSize, int inNum)
        {
            LevelName = inName;
            LevelSize = inSize;
            LevelNum = inNum;                       
        }
        // ... GetLevel methods here...
    }
