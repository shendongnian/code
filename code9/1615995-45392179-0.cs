    public class LetterBox
    {
        private TextBox[,] array = new TextBox[4, 4];
        public TextBox this[int x, int y]
        {
            get
            {
                return array[x, y];
            }
        }
    }
