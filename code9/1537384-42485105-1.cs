    public class JourneyPatterns : SpecializedList<JourneyPattern>
    {
        protected override string IdPrefix => "JP_";
    }
    public class JourneyPatternSections : SpecializedList<JourneyPatternSection>
    {
        protected override string IdPrefix => "JPS_";
    }
