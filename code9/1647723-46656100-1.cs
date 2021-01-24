    public struct Box
    {
        // a dictionary key should be immutable, therefore I use a struct
        // implement equality members so that when querying the dictionary,
        // it will find the value associated to the key
        // see https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type
    
        public int Width { get; }
        public int Height { get; }
    
        public Box(int width, int height)
        {
            Width = width;
            Height = height;
        }
    
        public bool Equals(Box other)
        {
            return Width == other.Width && Height == other.Height;
        }
    
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is Box && Equals((Box) obj);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
            }
        }
    
        public static bool operator ==(Box left, Box right)
        {
            return left.Equals(right);
        }
    
        public static bool operator !=(Box left, Box right)
        {
            return !left.Equals(right);
        }
    }
