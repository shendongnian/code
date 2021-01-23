    using System.Text;
    using Newtonsoft.Json;
    namespace System
    {
        public static class JsonExtensions
        {
            public static string ToFormattedJsonString(this object obj, bool indentWithTab)
            {
                return indentWithTab
                    ? ToFormattedJsonString(obj, "\t")
                    : ToFormattedJsonString(obj);
            }
            public static string ToFormattedJsonString(this object obj, string indentString = "  ")
            {
                return FormatJson(obj.ToJsonString(), indentString);
            }
            public static string ToJsonString(this object obj)
            {
                return JsonConvert.SerializeObject(obj);
            }
            public static T DeserializeJsonString<T>(this string jsonString)
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            private static string FormatJson(string jsonString, string indentString)
            {
                var indent = 0;
                var quoted = false;
                var builder = new StringBuilder();
                for (var i = 0; i < jsonString.Length; i++)
                {
                    var character = jsonString[i];
                    switch (character)
                    {
                        case '{':
                        case '[':
                            builder.Append(character);
                            if (!quoted)
                            {
                                builder.AppendLine();
                                builder.RepeatAppend(++indent, indentString);
                            }
                            break;
                        case '}':
                        case ']':
                            if (!quoted)
                            {
                                builder.AppendLine();
                                builder.RepeatAppend(--indent, indentString);
                            }
                            builder.Append(character);
                            break;
                        case '"':
                            builder.Append(character);
                            bool escaped = false;
                            var index = i;
                            while (index > 0 && jsonString[--index] == '\\')
                                escaped = !escaped;
                            if (!escaped)
                                quoted = !quoted;
                            break;
                        case ',':
                            builder.Append(character);
                            if (!quoted)
                            {
                                builder.AppendLine();
                                builder.RepeatAppend(indent, indentString);
                            }
                            break;
                        case ':':
                            builder.Append(character);
                            if (!quoted)
                                builder.Append(" ");
                            break;
                        default:
                            builder.Append(character);
                            break;
                    }
                }
                return builder.ToString();
            }
            public static StringBuilder RepeatAppend(this StringBuilder builder, int count, string format,
                params object[] parameters)
            {
                if (count <= 0 || string.IsNullOrEmpty(format))
                    return builder;
                for (int i = 0; i < count; i++)
                {
                    builder.AppendFormat(format, parameters);
                }
                return builder;
            }
        }
    }
