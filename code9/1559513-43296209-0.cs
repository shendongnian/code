    class Program
    {
        static void Main(string[] args)
        {
            
            var notAllowedWord= new NotAllowedWord("word");
            var input = "replace word  wo.rd also wor d and wor.d but not wordpress .";
            var replacedText = notAllowedWord.ReplaceNotAllowedWord(input);
            Console.WriteLine(replacedText);
            //output
            //replace **** ****also ****and ****but not wordpress .
            Console.ReadLine();
        }
        public class NotAllowedWord
        {
            private readonly string _word;
            private readonly Regex _wordRegEx;
            private readonly string _replacement;
            public NotAllowedWord(string word)
            {
                _word = word;
                _replacement=new string('*',word.Length);
                _wordRegEx = BuildRegExPattern();
            }
            private Regex BuildRegExPattern()
            {
                //TODO USE string builder                
                var pattern = "";
                //create space and . match pattern  
                // example given "word" it will produce "w[ ]*\.*o[ ]*\.*r[ ]*\.*l[ ]*\.*d"
                foreach (var c in _word)
                {
                    pattern = pattern + c + @"[ ]*\.*";
                }
                var regex = $"({_word}[ ])" + //Match the word
                        $"|({pattern}[ ])" + //match word that contains space or .
                        $"|({pattern}$)"  //match word that is at end of a sentence
                        ;
                //Console.WriteLine(regex);
                return new Regex(regex);
            }
            public string ReplaceNotAllowedWord(string inputText)
            {
                return _wordRegEx.Replace(inputText, _replacement);
            }
        }
    }
