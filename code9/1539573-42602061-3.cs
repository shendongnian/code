    [DataContract]
    [ProtoContract]
    public class ProductNameIndex
    {
        [ProtoMember(1, Name = "Products")]
        KeyValuePair<ProductName, ProductId>[] ProductsSurrogateArray
        {
            get
            {
                return Products.ToArray();
            }
            set
            {
                if (value == null)
                    return;
                foreach (var p in value)
                {
                    if (p.Key == null)
                        Debug.WriteLine("Ignoring invalid null key");
                    else
                        Products.Add(p);
                }
            }
        }
        [ProtoIgnore]
        [DataMember(Order = 1)]
        public IDictionary<ProductName, ProductId> Products { get; private set; }
        public ProductNameIndex()
        {
            this.Products = new Dictionary<ProductName, ProductId>();
        }
    }
