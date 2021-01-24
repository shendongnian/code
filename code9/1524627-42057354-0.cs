    public ObjectType
    {
        public double Column1 { get; set; }
        public double Column2 { get; set; }
        public double Column3 { get; set; }
        // avoid division by zero, adjust zero comparison threshold as needed
        // also adjust returned value on zero
        // using C# 6.0 specific syntax. If not available, use get { return } syntax 
        public NewCalculatedColumn => Math.Abs(Column3) > 0.0001 ?  
            (Column1 * Column2)/Column3 
            : 0.0;
    }
