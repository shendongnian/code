    private class Foo
    {
        public int Apple { get; set; }
        public Description Description { get; set; }
    }
    private class Description
    {
        public int[] HoursList { get; set; }
    }
    
    var a = new Foo
    {
        Apple = 1,
        Description = new Description
        {
            HoursList = new[] {1}
        }
    };
    var b = JsonConvert.SerializeObject(a);
