    [FallbackRoute("/{PathInfo*}")]
    public class FallbackForUnmatchedRoutes
    {
        public string PathInfo { get; set; }
    }
