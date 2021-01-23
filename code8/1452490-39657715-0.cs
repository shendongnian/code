    public class LithuanianString : IComparable<LithuanianString>
    {
        const string UpperAlphabet = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
        const string LowerAlphabet = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž";
        public string String;
        public LithuanianString(string inputString)
        {
            this.String = inputString;
        }
        public int CompareTo(LithuanianString other)
        {
            var maxIndex = this.String.Length <= other.String.Length ? this.String.Length : other.String.Length;
            for (var i = 0; i < maxIndex; i++)
            {
                //We make the method non case sensitive
                var indexOfThis = LowerAlphabet.Contains(this.String[i])
                    ? LowerAlphabet.IndexOf(this.String[i])
                    : UpperAlphabet.IndexOf(this.String[i]);
                var indexOfOther = LowerAlphabet.Contains(other.String[i])
                    ? LowerAlphabet.IndexOf(other.String[i])
                    : UpperAlphabet.IndexOf(other.String[i]);
                if (indexOfOther != indexOfThis)
                    return indexOfThis - indexOfOther;
            }
            return this.String.Length - other.String.Length;
        }
    }
