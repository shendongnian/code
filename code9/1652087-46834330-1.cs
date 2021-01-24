    public JsonResult GetCustomers(string stringOfCustomerIds )
    {
         JObject CustomerIdsJson = JObject.Parse(listOfCustomerIds );
  
           foreach (JProperty property in CustomerIdsJson .Properties())
           {
               Console.WriteLine(property.ID+ " - " + property.Value);
           }
          return Json(output, JsonRequestBehavior.AllowGet);  
    }
 
