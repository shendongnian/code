    public static partial class StringExtensions {
      public static string MaskPrefix(this string value, int count = 6) {
        if (null == value)
          throw new ArgumentNullException("value");
        else if (count < 0)
          throw new ArgumentOutOfRangeException("count");
        int length = Math.Min(value.Length, count);
        return new string('*', length) + string.Concat(value.Skip(length));
      }
    }
