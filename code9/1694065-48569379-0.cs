    [Serializable]
    public class Product2 : Product 
    {
        public new abstract class productFoo: PX.Data.IBqlField
        {
        }
        [PXDBString(15, IsUnicode = true)]
        [PXDefault()]
        [PXUIField(DisplayName = "Product Foo 2")]
        public override string ProductFoo
        {
            get
            {
                return this._ProductFoo;
            }
            set
            {
                this._ProductFoo = value;
            }
        }
    }
