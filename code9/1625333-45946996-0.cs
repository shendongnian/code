    public class AlgorithmA : Algorithm
    {
        public override List<Block> Blocks
        {
            get
            {
                return new List<Block> { new ABlock(), new ABlock() };
            }
        }
    }
