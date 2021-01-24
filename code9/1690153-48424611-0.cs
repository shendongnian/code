        public static void TakeBetween(string filePath, string startText, string endText)
        {
            var data = File.ReadLines(filePath).SkipWhile(line => !line.Contains(startText)).Skip(1).TakeWhile(line => !line.Contains(endText));
            // Do whatever that is needed with data. It is of type IEnumerable<string>
        }
