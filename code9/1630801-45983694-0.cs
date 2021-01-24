    var urlDecoded = HttpUtility.UrlDecode("jwt string here");
    var obj = JsonConvert.DeserializeObject<JWtObject>(urlDecoded);
    public class JWtObject
    {
        public string Identity { get; set; }
        public int LoggedInId { get; set; }
        public int AgencyId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int UserTypeId { get; set; }
    }
