    public class TextSectionDefinition
    {
        public enum MultiLine
        {
            singleLine,         // A single line without text body, e.g. title
            multiLine,          // Multiple lines, all match predicate, e.g. emails  
            multiLineHeader,    // Multiple lines, first line matches as header, e.g. h1
            multiLineIntro      // Multiple lines, first line matches inline, e.g. abstract
        }
    
        public TextSectionDefinition(String name, Predicate<List<List<TextPosition>>> matchPredicate, MultiLine multiLine, boolean multiple)
        {
            this.name = name;
            this.matchPredicate = matchPredicate;
            this.multiLine = multiLine;
            this.multiple = multiple;
        }
    
        final String name;
        final Predicate<List<List<TextPosition>>> matchPredicate;
        final MultiLine multiLine;
        final boolean multiple;
    }
