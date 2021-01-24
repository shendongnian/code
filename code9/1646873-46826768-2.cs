    internal static class Tokenizer
    {
        public static IEnumerable<Token> Scan (string expression)
        {
            var words = new Queue<string>
                (expression.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries));
            while (words.Any())
            {
                string word = words.Dequeue();
                switch (word)
                {
                    case "id":
                        yield return new OpenNodeToken(words.Dequeue());
                        words.Dequeue();
                        break;
                    case "}":
                        yield return new CloseNodeToken();
                        break;
                    default:
                        yield return new ContentToken(word);
                        break;
                }
            }
        }
    }
