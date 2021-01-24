    public class ApplicationUser : IdentityUser
    {
        public long UserImageId { get; set; }
        public UserImage UserImage { get; set; }
    }
    
    public class UserImage
    {
        public long Id { get; set; }
        public byte[] UserImageBlob { get; set; }
        public string UserImageFileName { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
