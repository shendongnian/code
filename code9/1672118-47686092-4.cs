    public sealed class Word
    {
        public Single Probability { get; private set; }
        public String Text { get; private set; }
        public Word(Single probability, String text)
        {
            Probability = probability;
            Text = text;
        }
    }
    List<Word> adjectives = new List<Word>
    {
        new Word(1.000f, "Beautiful"),
        new Word(0.748f, "Wonderful"),
        new Word(0.732f, "Lovely")
    };
    List<Word> nouns = new List<Word>
    {
        new Word(1.000f, "Queen"),
        new Word(0.767f, "Princess"),
        new Word(0.702f, "Empress")
    };      
    List<Word> words = adjectives
        .SelectMany(
            a => 
            nouns.Select(
                n => 
                new Word(((a.Probability + n.Probability) / 2.0f), String.Concat(a.Text, " ", n.Text))
            )
        )
        .ToList();
    for (Int32 i = 0; i < words.Count; ++i)
    {
        Word word = words[i];
        Console.WriteLine(word.Probability.ToString("N4") + " - " + word.Text);
    }
