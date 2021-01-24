        public static string MergeWithPrefix(this ArrayList list, string prefix, string separator = ";")
        {
            var sb = new StringBuilder(list.Count * 16);
            foreach (var item in list)
                sb.Append(prefix).Append(item).Append(separator);
            sb.Remove(sb.Length - separator.Length, separator.Length);
            return sb.ToString();
        }
