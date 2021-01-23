       public ActionResult MyExport()
       {
            SetResponseToText("MyFilename.csv");
            Response.Write(String.Format("\"{0}\",...,{26}",
               "Heading 1", ..., Environment.NewLine));
            Response.Flush();
            IEnumerable<MyClass> exportData = _MyService.GetMyData();
            foreach (var row in exportData)
            {
                Response.Write(String.Format("\"{0}\"...,{26}",
                    "\t" + row.Field1, //tab character to force Excel to treat it as text
                     row.Field2, ..., Environment.NewLine));
            }
            Response.Flush();
            Response.End();
            return null;
        }
