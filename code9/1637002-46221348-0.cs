    public class ItemBase
    {
        [DisplayName("Base Foo")]
        public virtual String Foo { get; set; }
        [DisplayName("All Bar")]
        public virtual String Bar { get; set; }
    }
    public class ItemSub : Item
    {
        [DisplayName("Sub Foo")]
        public override String Foo { get; set; }
    }
