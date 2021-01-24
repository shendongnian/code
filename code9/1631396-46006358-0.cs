    //Notice the third sentence would have the correct syntax
    string text = "A Dog is no Cat.My Dog is a Cat.A Dog is a Cat.";
    //Splitting text into single sentences
    string[] sentences = text.Split(new char[] { '.' });
    string[] wordsToMatch = { "A", "*", "is", "a", "*" };
    var sentenceQuery = from sentence in sentences
                        let words = sentence.Split(' ')
                        where words.Length == wordsToMatch.Length && 
                              wordsToMatch.Zip(words, (f, s) => f == "*" || f == s).All(p => p)
                        select sentence;
