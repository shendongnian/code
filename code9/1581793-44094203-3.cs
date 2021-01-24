    public class SourceAResolver : IValueResolver<SourceA, Intermediate, SourceA>
    {
        public SourceA Resolve(SourceA source, Intermediate destination, SourceA destMember, ResolutionContext context)
        {
            return source;
        }
    }
    public class SourceBResolver : IValueResolver<SourceB, Intermediate, SourceB>
    {
        public SourceB Resolve(SourceB source, Intermediate destination, SourceB destMember, ResolutionContext context)
        {
            return source;
        }
    }
