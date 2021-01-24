    public static class StringBuilderExtensions
    {
        public static void AppendPadded(this StringBuilder builder, string value, int length);
        {
            builder.Append($"{value}{new string(" ", length)}".Substring(0, length));
        }
        public static void AppendPadded(this StringBuilder builder, int value, int length);
        {
            builder.Append($"{new string("0", length)}{value}".Reverse().ToString().Substring(0, length).Reverse().ToString());
        }
    }
