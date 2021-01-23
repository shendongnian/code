    #r "System.Data.Linq"
    #r "System.Data"
    
    using System.Data.Linq.Mapping;
    using System.Data;
    
    [Table(Name = "TodoItem")]
    public class todoItem
    {
        private string _id;
        [Column(IsPrimaryKey=true, Storage="_id")]
        public string id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
    
        }
    
        private string _text;
        [Column(Storage="_text")]
        public string text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text=value;
            }
        }
    }
