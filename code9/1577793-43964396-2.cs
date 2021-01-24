    public static class PluralizeExtensions {
        private static Dictionary<string, string> pluralForms = new Dictionary<string, string> {
            { "letter", "letters" },
            { "corresponds", "correspond" },
            { "It", "They" }
        };
        public static string Pluralize(this string text, bool isPlural) {
            if (!isPlural) return text;
            var words = text.Split(' ');
            for (int i = 0; i < words.Length; i++) {
                if (pluralForms.ContainsKey(words[i])) words[i] = pluralForms[words[i]];
            }
            return string.Join(" ", words);
        }
    }
