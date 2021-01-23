    public sealed class CustomTransformer: IResultTransformer
        {
            public IList TransformList(IList collection)
            {
                return collection;
            }
    
            public object TransformTuple(object[] tuple, string[] aliases)
            {
                return new UniqueCustomerPurchase()
                {
                       CustomerName = (string)tuple[0],
                       PaymentType = (string)tuple[1],
                       Total = (uint)tuple[2]
                };
            }
        }
