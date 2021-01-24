    [DataContract(Name = "FooOf{0}")]
    public class Foo<T>
    {
        [DataMemberAttribute(Name = "Value")]
        public T Value { get; set; }
    }
