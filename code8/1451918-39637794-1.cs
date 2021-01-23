    class MyEntity : TableEntity
    {
        public string LongString { get; set; }
        public bool IsCompressed { get; set; }
    
        public override void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
        {
            base.ReadEntity(properties, operationContext);
    
            if (IsCompressed)
            {
                LongString = Decompress(LongString);
                IsCompressed = false;
            }
        }
    
        public override IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
        {
            if (LongString.Length > 64KB)
            {
                LongString = Compress(LongString);
                IsCompressed = true;
            }
    
            return base.WriteEntity(operationContext);
        }
    }
