    var newString = HexReplace(sourceString, "C2B0", "B0");
        private static string HexReplace(string source, string search, string replaceWith) {
            var realSearch = string.Empty;
            var realReplace = string.Empty;
            if(search.Length % 2 == 1) throw new Exception("Search parameter incorrect!");
            for (var i = 0; i < search.Length / 2; i++) {
                var hex = search.Substring(i * 2, 2);
                realSearch += (char)int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }
            for (var i = 0; i < replaceWith.Length / 2; i++) {
                var hex = replaceWith.Substring(i * 2, 2);
                realReplace += (char)int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }
            return source.Replace(realSearch, realReplace);
        }
