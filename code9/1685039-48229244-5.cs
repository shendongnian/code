    public class MyTest
    {
        [MaxLength(250)]
        [DefaultValue("HelloWorld")]
        public string Name { get; set; }
        public bool IsPassing { get; set; }
    }
