    public static class StringBuilderExtensions
    {
        public static void AppendPadded(this StringBuilder builder, string value, int length);
        {
            builder.Append($"{value}{new string(" ", length)}".Substring(0, length));
        }
    }
