    class Group
    {
        public int StartIndex { get; set; }
    
        public int EndIndex { get; set; }
    
        public int Length { get { return EndIndex - StartIndex; } }
    
        public override string ToString()
        {
            return $"{StartIndex}-{EndIndex}";
        }
    }
