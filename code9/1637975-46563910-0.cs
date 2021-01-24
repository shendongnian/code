    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<DiacriticsKerning>();
            list.Add(new DiacriticsKerning('א', 'ָ', HorizontalAlignment.Center, VerticalAlignment.None));
            list.Add(new DiacriticsKerning('ב', 'ָ', HorizontalAlignment.Center, VerticalAlignment.None));
            list.Add(new DiacriticsKerning('ג', 'ָ', HorizontalAlignment.Center, VerticalAlignment.None));
            list.Add(new DiacriticsKerning('ד', 'ָ', HorizontalAlignment.Right, VerticalAlignment.None));
            list.Add(new DiacriticsKerning('ה', 'ָ', HorizontalAlignment.Center, VerticalAlignment.None));
            list.Add(new DiacriticsKerning('ו', 'ָ', HorizontalAlignment.Center, VerticalAlignment.None));
            // ...
        }
    }
    struct DiacriticsKerning
    {
        public DiacriticsKerning(char letter, char diacritics, HorizontalAlignment alignmentHorizontal, VerticalAlignment alignmentVertical)
        {
            Letters = letter;
            Diacritics = diacritics;
            HorizontalAlignment = alignmentHorizontal;
            VerticalAlignment = alignmentVertical;
        }
        char Letters;
        char Diacritics;
        HorizontalAlignment HorizontalAlignment;
        VerticalAlignment VerticalAlignment;
    }
    enum HorizontalAlignment { None, Center, Left, Right, }
    enum VerticalAlignment { None, Center, Left, Right, }
