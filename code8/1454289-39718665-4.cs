    public class RevisionNumber
    {
        private static readonly string[] _Representations = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private int _Value;
        public void Increment()
        {
            _Value++;
        }
        public override string ToString()
        {
            var result = String.Empty;
            var value = _Value;
            while (value >= _Representations.Length)
            {
                result = _Representations[(int)value % _Representations.Length] + result;
                value /= _Representations.Length;
                value--;
            }
            return _Representations[(int)value] + result;
        }
    }
