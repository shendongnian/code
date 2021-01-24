    public struct sValues
    {
        public string ObjectName {get;private set;}
        public int Value {get; private set;}
        public sValues(string objectName, int Value)
        {
            ObjectName = objectName;
            this.Value = Value;
        }
    }
