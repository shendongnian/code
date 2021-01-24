        private static Dictionary<string, Func<Product,IComparable>> lookup= new 
      Dictionary<string, Func<Product,IComparable>>() { { "S", NewMethod}, { "D", NewMethodD}};
        
        
                private static IComparable NewMethod(Product a)
                {
                    return a.SKU;
                }
                private static IComparable NewMethodD(Product a)
                {
                    return  a.OtherTHing;
                }
