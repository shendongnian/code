    1. Create a response class
    public class JsonReaponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } 
        public object Data { get; set; } = new List<string>();
    }
    2. Use a response class with object
    JsonReaponse reaponse = new JsonReaponse();
    if (words.Length > 0)
    {
        PANCard pc = new PANCard();
        if (words[0] == "1" && words[2] == "E")
        {
            pc.PANNumber = words[1];
            pc.LastName = words[3];
            pc.FirstName = words[4];
            pc.MiddleName = words[5];
            pc.Title = words[6];
            pc.LastUpdated = words[7]; ////DateTime.ParseExact(words[7], @"d/M/yyyy", culture);
            var panno = pc.Title + " " + pc.FirstName + " " + pc.MiddleName + " " + pc.LastName;
            reaponse.Message = "Your Message";
            reaponse.Data = panno;
            return Json(reaponse, JsonRequestBehavior.AllowGet);
        }
    }
                
    3. In jQuery
    success: function (res) {
        var msgi = res.Message;
        var panno = res.Data;
        if (msgi != "A" && msgi != "B") {
            alert(msgi); ////// Here undefined is showing
            $("#Item3_PANNumber").focus();
            $("#Item3_PANNumber").val('');
        }                         
    }
