    public static class InstagramSubComponent : ISocialComponent
    {
        public static SomeStatsObject GetStats(string hashTag)
        {
            return stuff;
        }
    }
    public class MainSocialComponent : ISocialComponent
    {
        //this is an enum
        private RequestedNetwork _requestedNetwork{ get; set;}
        private static var Mappings = new Dictionary<string, Func<SomeStatsObject>> {
            { "Twitter", TwitterSubComponent.GetStats },
            { "Facebook", FacebookSubComponent.GetStats },
            { "Instagram", InstagramSubComponent.GetStats }
        } 
        public SomeStatsObject GetStats(string hashTag) 
        {
           return Mappings[hashTag].invoke(); 
        }
    }
