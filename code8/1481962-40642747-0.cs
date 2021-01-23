    public class Product
    {
        public int ID { get; set; }
        [XmlIgnore]
        public List<Styles> ProductSyles { get; set; }
        [XmlArray("ProductStyles")]
        public Styles [] SerializableProductSyles 
        {
            get
            {
                if (ProductSyles == null)
                    return null;
                return ProductSyles.Where(s => s.Selected).ToArray();
            }
            set
            {
                if (value == null)
                    return;
                ProductSyles = ProductSyles ?? new List<Styles>();
                ProductSyles.AddRange(value);
            }
        }
    }
