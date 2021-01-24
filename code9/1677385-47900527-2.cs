    using System.ComponentModel.DataAnnotations;
    public class Asset
    {
        [RegularExpression("^[A-Z][a-zA-Z]*$")]
        public string Id { get; set; }
    }
