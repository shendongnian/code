    public class __Enhanced__Stock__ {
        private static readonly EnhancedAttribute[] __Price__Attributes__;
        static __Enhanced__Stock__() {
            __Price__Attributes__ = typeof(Stock).GetProperty("Price")
                                                .GetCustomAttributes<EnhancedAtributte>()
                                                .ToArray();
        }
        public override int Price {
            get => base.Price;
            set {
                for (int i = 0, n = __Price__Attributes__.Length; i < n; i++) 
                    __Price__Attributes__[i].Check(new Object[] { (Object)value });
                }
                base.Price = value;
            }
        }
    }
