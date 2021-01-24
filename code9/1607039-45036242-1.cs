    public sealed class IDbMapper : ClassMapper<IDb>
    {
        public IDbMapper()
        {
            base.Table("TableName");
            Map(m => new DbModel().Title);
            // and such mapping for other properties
        }
    }
