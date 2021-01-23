    public class Product
    {
        public int Id { get; set; }
        [Required]
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
    }
    //using variables of the previous code examples
    myProduct.FileData = data;
    myProduct.FileName = file.FileName;
 
