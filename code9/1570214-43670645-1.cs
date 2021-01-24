    public sealed class InterpolatedString {
       public InterpolatedString(string stringWithPlaceholders, params string[] values) {
          StringWithPlaceHolders = stringWithPlaceHolders;
          Values = values;
       }
       public string StringWithPlaceHolders { get; }
       public string[] Values { get; }
       public override string ToString() => string.Format(StringWithPlaceholders, Values);
    }
