        public static string UnicodeSafeSubstring(this string str, int startIndex, int length)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (startIndex < 0 || startIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (startIndex + length > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (length == 0)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder(length);
            
            var enumerator = StringInfo.GetTextElementEnumerator(str, startIndex);
            while (enumerator.MoveNext())
            {
                var grapheme = enumerator.GetTextElement();
                startIndex += grapheme.Length;
                if (startIndex > str.Length)
                {
                    break;
                }
                // Skip initial Low Surrogates/Combining Marks
                if (stringBuilder.Length == 0)
                {
                    if (char.IsLowSurrogate(grapheme[0]))
                    {
                        continue;
                    }
                    var cat = char.GetUnicodeCategory(grapheme, 0);
                    if (cat == UnicodeCategory.NonSpacingMark || cat == UnicodeCategory.SpacingCombiningMark || cat == UnicodeCategory.EnclosingMark)
                    {
                        continue;
                    }
                }
                // Do not append the grapheme if the resulting string would be longer than the required length
                if (stringBuilder.Length + grapheme.Length <= length)
                {
                    stringBuilder.Append(grapheme);
                }
                if (stringBuilder.Length >= length)
                {
                    break;
                }
            }
            return stringBuilder.ToString();
        }
    }
