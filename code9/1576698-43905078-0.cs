    public class Sample
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public object Test()
        {
            return new { FirstName = "William Smith" };
        }
    }
