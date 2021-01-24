    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity>GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,  DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        //There you can use display name or any attributes like a regular Model.
        public LevelEnum Level { get; set; }
        [Display(Name = "Is allowed to process")]
        public bool CanProcess { get; set; }
        public bool CanWorkOffline { get; set; }
        public bool CanSendEmail { get; set; }
        public bool CanViewFullName { get; set; }
    }
