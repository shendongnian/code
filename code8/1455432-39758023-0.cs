       public interface IProduct
        {
            string No { get; }
            string CodeName { get; }
            string Family { get; }
            string ModelNo { get; }
            string CodeInfo { get; }
            IDictionary<string, string> FieldMapping { get; }
        }
