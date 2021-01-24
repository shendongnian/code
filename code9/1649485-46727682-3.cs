      //Call below function like 
       
     var jsonZipCodes = GetLocationInZips("34520,63631,45628");
      public static string GetLocationInZips(string strZipCodes)
        {
            string jarrZipCodes = string.Empty;
            JObject response = new JObject();
            try
            {
         
         //       jarrZipCodes = JsonConvert.SerializeObject(strZipCodes.Split(','));
               jarrZipCodes = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(strZipCodes.Split(','));
                return jarrZipCodes;
            }
            catch (Exception ex)
            {
                response["success"] = false;
                response["error"] = "Failed to serialize zip code array, please check and try again";
                response["exception"] = ex.ToString();
                return response.ToString();
            }
        }
