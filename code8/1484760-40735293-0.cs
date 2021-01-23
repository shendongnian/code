    // This is the base class declared as the view's @model
    // This one would have all the common validations
    public class TestViewModel
    {
        public string ModelType { get; set; }
        public virtual string Prop1 { get; set; }
        public virtual string Prop2 { get; set; }
        public virtual string Prop3 { get; set; }
    }
    public class TestViewModel1 : TestViewModel
    {
        [Required]
        public override string Prop1 { get; set; }
    }
    public class TestViewModel2 : TestViewModel
    {
        [Required]
        public override string Prop1 { get; set; }
        [Required]
        public override string Prop2 { get; set; }
    }
