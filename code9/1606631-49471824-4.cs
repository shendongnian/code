    public class Dto
    {
        public IFormFile MyFile {get;set;}
    
        [FromForm]
        public MyJson MyJson {get;set;}
    }
