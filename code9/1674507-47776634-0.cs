    [HttpGet]
    public JsonResult AddTextFile(MyObject obj) {
        if(!ModelState.IsValid) { 
            // return error 
        }
    }
    
    public class MyObject {
        [Required]
        public string Path { get; set; }
    }
