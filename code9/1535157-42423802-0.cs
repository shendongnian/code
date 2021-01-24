    public class MakeSymbol: SequenceFixture {
        public void Embed(string symbolName, string content, string replacement) {
            Symbols.Save(symbolName, content.Replace("$", replacement));
        }
    }
