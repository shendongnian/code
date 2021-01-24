    public class Cart {
        public virtual string Currency { get; set; } // I'm trying to override this
    }
    
    // My fake class
    public class CartFake : Cart
    {
        public override string Currency {  // This should hide SomeBaseBase.Cart.Currency - but it does not
            get { return "USD"; }
            set { value = "USD"; }
        }
    }
