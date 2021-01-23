    public class Position
    {
        public int l { get; set; }
        public int r { get; set; }
        public int t { get; set; }
        public int b { get; set; }
        public override string ToString()
        {
            return $"l = {l}, r = {r}, t = {t}, b = {b}";
        }
    }
