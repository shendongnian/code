    public class CreateUserApiRequest : ApiRequest {
        [DataMember]
        [Length(128)]
        [Description("クライアントキー")]
        public byte[] clientKey { get; set; }
        ....
