    public class MyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Func<MyType, bool> GetQuery()
        {
            // or whatever equals you would like
            return x => x.Name == this.Name && x.Id == this.Id;
        }
    }
