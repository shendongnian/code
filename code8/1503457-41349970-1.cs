        public class Bank {
           //Standard fields that are mapped to a table in database 
           public Status StatusEnum {
             get {
                Status.FromInteger(StatusId); //StatusId is a property mapped to table's field
             }
            
             set {
                //TODO Handle null value
                StatusId = value.Value;
             }
           }
        }
