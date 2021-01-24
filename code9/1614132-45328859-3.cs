     private void UpdateValueInJavascriptGraph()
     {
         var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
         var json = serializer.Serialize(MyArrayOfData);  
         object result = this.WBTimeGraph.InvokeScript("UpdateGraph", new object[] { json });
     }
