    public class UserMapper : CrudEntityMapper<User>
    {
        public UserMapper() : base("User")
        {
            Property(x => x.UserType.Id)
                .ColumnName("UserTypeId");
            Property(x => x.UserType.Name)
                .ColumnName("UserTypeName");
        }
    }
