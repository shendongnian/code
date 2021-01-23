    public interface IProduct
        {
            string No { get; }
            string CodeName { get; }
            string Family { get; }
            string ModelNo { get; }
            string SalesCode { get; }
            string CodeInfo { get; }
            IEnumerable<IProductAttribute> Attributes { get; }
        }
        public interface IProductAttribute
        {
            string InternalHeading { get; }
            int Index { get; } //not sure what this is for.
        }
