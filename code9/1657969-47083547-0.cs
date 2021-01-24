    public struct Vector3 : IEnumerable<float>
    {
        // Remember mutable structs are evil. 
        // Always make fields readonly if possible.
        public readonly float x;
        public readonly float y;
        public readonly float z;
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public IEnumerator<float> GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector3 a = new Vector3(2f, -1f, 3f);
            float[] vals = a.ToArray();
            float sum = a.Sum();
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
