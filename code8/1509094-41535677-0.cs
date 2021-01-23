    public class GameWord
    {
        public string OriginalWord { get; set; }
        public string GuessWord { get; set; }
    
        public string Hint()
        {
            int index = this.GuessWord.IndexOf('_');
            if (index != -1)
            {
                var builder = new StringBuilder(this.GuessWord);
                builder[index] = this.OriginalWord[index];
    
                this.GuessWord = builder.ToString();
    
                return this.GuessWord; // if needed
            }
    
            // No more hints, the world has no underscores
            return this.GuessWord;
        }
    }
