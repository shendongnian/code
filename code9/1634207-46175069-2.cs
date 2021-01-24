    [JsonObject(MemberSerialization.OptOut)]
    public class QueryResult<T>
    {
        [JsonConstructor]
        public QueryResult(T Result, ResultState State, 
                Dictionary<string, string> AdditionalInformation)
        {
            this.Result = result;
            this.State = state;
            this.AdditionalInformation = AdditionalInformation;
        }
        public T Result { get; }
        public ResultState State { get; }
        public Dictionary<string, string> AdditionalInformation { get; }
    }
    public enum ResultState : byte
    {
        0 = Success,
        1 = Obsolete,
        2 = AuthenticationError,
        4 = DatabaseError,
        8 = ....
    }
