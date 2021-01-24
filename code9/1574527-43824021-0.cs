    public class User
    {
        public int UserId { get; set; }
        [NotMapped]
        [ScriptIgnore]
        public string ImageFileName { get; private set; }
    
        [NotMapped]
        public bool IsNewItem { get; set; }
         
        [NotMapped]
        public string UserImage
        {
            get { return this.ImageFileName; }
            set { this.ImageFileName = CreateImage(value); }
        }
    
        private string CreateImage(string value)
        {
            return 
                IsNewItem
                    ? new CreateFile().SetData(this.ImageFileName, value).Image()      
                    : value;
        }
     }
