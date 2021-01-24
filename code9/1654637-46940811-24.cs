    namespace DL.SO.Services.Security
    {
        public class AppIdentitySettings
        {
            public UserSettings User { get; set; }
            public PasswordSettings Password { get; set; }
            public LockoutSettings Lockout { get; set; }
        }
        public class UserSettings
        {
            public bool RequireUniqueEmail { get; set; }
        }
        public class PasswordSettings
        {
            public int RequiredLength { get; set; }
            public bool RequireLowercase { get; set; }
            public bool RequireUppercase { get; set; }
            public bool RequireDigit { get; set; }
            public bool RequireNonAlphanumeric { get; set; }
        }
        public class LockoutSettings
        {
            public bool AllowedForNewUsers { get; set; }
            public int DefaultLockoutTimeSpanInMins { get; set; }
            public int MaxFailedAccessAttempts { get; set; }
        }
    }
