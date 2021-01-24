    public class MustHaveMoreThanOneItemAttribute : ValidationAttribute
    {
        public Type EnumerableType { get; }
        public MustHaveMoreThanOneItemAttribute(Type t)
            => this.EnumerableType = typeof(ICollection<>).MakeGenericType(t);
        public override bool IsValid(object value)
        {
            var count = this.EnumerableType.GetProperty("Count").GetValue(value) as int?;
            return (count ?? 0) > 1;
        }
    }
