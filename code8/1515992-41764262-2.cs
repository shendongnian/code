    public class FaceCountResult
    {
        public int Count { get; set; }
        public Face FaceValue { get; set; }
    
        public FaceCountResult(int count, Face faceValue)
        {
            Count = count;
            FaceValue = faceValue;
        }
    }
