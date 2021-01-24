    interface IClause
    {
        string Field { get; set; }
        string Operator { get; set; }
    }
    public class WhereClause : IClause
    {
        public string Field { get; set; }
        public string Operator { get; set; }
    }
    public class HavingFilter : IClause
    {
        public string Field { get; set; }
        public string Operator { get; set; }
    }
