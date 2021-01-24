        /// <summary>
    /// Actual database repository facade for BOX
    /// </summary>
    internal sealed class BusinessObjectXDatabaseRepo
    {
        public BusinessObjectXPoco CreateNew()
        {
            throw new NotImplementedException("Create in database and return POCO");
        }
    }
    /// <summary>
    /// ORM Poco for BOX.
    /// </summary>
    internal sealed class BusinessObjectXPoco
    {
        public Guid Id { get; set; }
        public string SomeProperty { get; set; }
    }
