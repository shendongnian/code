     [System.Web.Services.WebMethod]
        public static MyObject GetMyObject()
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
            return obj;
        }
