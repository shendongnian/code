     public class Range<T> where T : IComparable<T>
        {
            public T Minimum { get; set; }
            public T Maximum { get; set; }
            public Range(T Minimum, T Maximum)
            {
                this.Minimum = Minimum;
                this.Maximum = Maximum;
                if (!IsValid())
                {
                    this.Minimum = Maximum;
                    this.Maximum = Minimum;
                }
            }
            public int GetRandomNumber()
            {
                if (typeof(T) == typeof(int))
                {
                    return new Random().Next(Convert.ToInt32(Minimum), Convert.ToInt32(Maximum));
                }
                else
                    throw new Exception("Given type is not integer.");
            }
            public bool IsValid()
            {
                return this.Minimum.CompareTo(this.Maximum) <= 0;
            }
        }
