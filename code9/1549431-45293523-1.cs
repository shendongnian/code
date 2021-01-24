    public class RawDataBlockEntity : ExtEntity<RawDataBlock>
    {
        public RawDataBlockEntity(string rawDataId, string blockId, RawDataBlock block)
        {
            this.PartitionKey = rawDataId;
            this.RowKey = blockId;
            this.Value = block;
        }
        public RawDataBlockEntity() { }
    }
