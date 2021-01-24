    public class ApplicationUserDto: BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<IdentityUserRole<string>> Roles{ get; set; }
    
        public static Expression<Func<ApplicationUser, ApplicationUserDto>> SelectProperties = (user) => new ApplicationUserDto {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Roles = user.Roles.ToList()
        };
    }
