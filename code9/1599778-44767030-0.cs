    [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
    pubic void Foo(UserEventArgs eventArgs, ILambdaContext context) {
     //do something
    }
    [Serializable()]
    public class UserEventArgs : EventArgs {
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
