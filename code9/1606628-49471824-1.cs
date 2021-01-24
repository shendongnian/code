    public class Dto
    {
        public IFormFile MyFile {get;set;}
    
        [ModelBinder(BinderType = typeof(FormDataJsonBinder))]
        public MyJson MyJson {get;set;}
    }
