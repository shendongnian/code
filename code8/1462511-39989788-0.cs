    public static class MappingExtensions
    {
        public ThisNameSpace.User ToThisUser(this OtherNameSpace.User source)
        {
            return new ThisNameSpace.User
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                UserId = source.UserId
            }
        }
    }
