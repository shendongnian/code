    class DateTimeComparer : IComparer<MyType> {
    
        readonly ObjectIDGenerator idGenerator = new ObjectIDGenerator();
    
        public int Compare(MyType x, MyType y) 	{
            if (x.DateTimeProp != y.DateTimeProp)
                return x.DateTimeProp.CompareTo(y.DateTimeProp);
            bool firstTime;
            var xId = idGenerator.GetId(x, out firstTime);
            var yId = idGenerator.GetId(y, out firstTime);
            return xId.CompareTo(yId);
        }
    }
