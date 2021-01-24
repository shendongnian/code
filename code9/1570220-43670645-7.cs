    public sealed class InterpolatedString {
       public InterpolatedString(string stringWithPlaceholders, params string[] values) {
          StringWithPlaceholders = stringWithPlaceholders;
          Values = values;
       }
       public string StringWithPlaceholders { get; }
       public string[] Values { get; }
       public override string ToString() => string.Format(StringWithPlaceholders, Values);
    }
