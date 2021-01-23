        #r "System.Data.Linq.dll"
     
        using System.Data.Linq.Mapping;
    
        [Table(Name = "TodoItems")]
        public class TodoItem
        {
           [Column]
           public string Id;
           [Column]
           public string Text;
           [Column]
           public bool Complete;
        }
