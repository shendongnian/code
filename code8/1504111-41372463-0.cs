      public class MyFucntion
    {
        public string SeriesName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
    }
    public class MyObject {
        public MyFucntion myFun { get; set; }
        public string Element1 { get; set; }
        public string Element2 { get; set; }
    }
    public JsonResult GetMyObject()
        {
            var fun = new MyFucntion
            {
                SeriesName =params[0].name,
                Max = params[0].value[3],
                Min = params[0].value[2],
                Start =params[0].value[0],
                End = params[0].value[1]
            };
            var obj = new MyObject {
                myFun = fun,
                Element1 ="ElE",
                Element2 = "ELE2"
            };
            return JSON(obj);
        }
