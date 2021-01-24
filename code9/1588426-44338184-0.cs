    public class TrainComposition
    {
        public List<int> LeftWagons1 { get; set; }
        public List<int> RightWagons1 { get; set; }
        public void AttachWagonFromLeft(int wagonId)
        {
            this.LeftWagons1.Add(wagonId);
        }
        public void AttachWagonFromRight(int wagonId)
        {
            this.RightWagons1.Add(wagonId);
        }
    }
