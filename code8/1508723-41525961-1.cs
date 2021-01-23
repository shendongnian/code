     // rowDTO.css created for catching the posted data
     public class rowDTO
     {
        public string td1 {get;set;}
        public string td2 {get;set;}
        public string td3 {get;set;}
        public string td4 {get;set;}
        public string td5 {get;set;}
        public string td6 {get;set;}
        public string td7 {get;set;}
     }
     // in the controller
     [HttpPost]
     public JsonResult catchRowData(rowDTO data)
     {
         // put your codes..
         return View();
     }
