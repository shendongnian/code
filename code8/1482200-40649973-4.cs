    public class Class1
    {
        public string Class1Prop { get; set; }
        public ICollection<Class1Data> Data { get; set; }
        private string GetProp()
        {
            return Class1Prop;
        }
        public void ParentLookup()
        {
            foreach(var data in Data)
            {
                data.AcquiresParentProp = GetProp;
            }
        }
    }
