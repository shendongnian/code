    public interface ICanCheckEndsWith
    {
        bool EndsWith(string end);
    }
    public class StringWrapper : ICanCheckEndsWith
    {
        public string String { get; set; }
        public bool EndsWith(string end)
        {
            return String.EndsWith(end);
        }
    }
    public class GoodBuffer<T> where T : ICanCheckEndsWith
    {
        private List<T> buffer = new List<T>();
        public bool CheckEndsWithBall()
        {
            return buffer.TrueForAll(b => b.EndsWith("ball"));
        }
    }
