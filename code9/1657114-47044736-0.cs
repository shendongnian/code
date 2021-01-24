    public abstract class UserRoleType : Enumeration<UserRoleType>
    {
        protected UserRoleType(int value, string displayName) 
            : base(value, displayName)
        {}
        public static readonly UserRoleType Unknown = new UnknownRoleType();
        public static readonly UserRoleType Administrator = new AdministratorRoleType();
        public static readonly UserRoleType System = new SystemRoleType();
        public static readonly UserRoleType Moderator = new ModeratorRoleType();
        public virtual bool CanCreateUser => false;
        public virtual bool CanBlockUser => false;
        public virtual bool CanResetUserPassword => false;
    }
    public sealed class UnknownRoleType : UserRoleType
    {
        public UnknownRoleType()
            : base(0, "Unknown")
        { }
    }
    public sealed class AdministratorRoleType : UserRoleType
    {
        public AdministratorRoleType()
            : base(10, "Administrator")
        {}
        public override bool CanCreateUser => true;
        public override bool CanBlockUser => true;
        public override bool CanResetUserPassword => true;
    }
    public sealed class SystemRoleType : UserRoleType
    {
        public SystemRoleType()
            : base(20, "System")
        { }
        public override bool CanBlockUser => true;
        public override bool CanResetUserPassword => true;
    }
    public sealed class ModeratorRoleType : UserRoleType
    {
        public ModeratorRoleType()
            : base(40, "Moderator")
        { }
        public override bool CanBlockUser => true;
    }
