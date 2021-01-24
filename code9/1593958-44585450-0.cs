            public static bool ContainsTrailingCommas(string json)
            {
                var template = Regex.Replace(json, @"\t|\n|\r|\s+|\"".*?\""", string.Empty);
                return template.Contains(",}");
            }
