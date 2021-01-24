    public class File {
        public byte[] file {get;set;}
        public Employee Employee {get;set;}
        public Contract Contract {get;set;}
    
        public IFileHolder Host{
            get{ return Employee ?? Contract; }
        }
    }
