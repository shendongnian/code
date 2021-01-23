    public class SourceToDestinationConverter : ITypeConverter<Source, Destination>
    {
        private int currentRank;
        public SourceToDestinationConverter(int rank)
        {
            currentRank = rank;
        }
        
        public Destination Convert(Source source, Destination destination, ResolutionContext context)
        {
            destination = new Destination
            {
                Value1 = source.Value1,
                Ranking = currentRank
            };
            return destination;
        }
    }
