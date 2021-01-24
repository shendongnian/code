    public static string GetLocationInZips(string strZipCodes)
            {
                JArray jarrZipCodes = new JArray();
                JObject response = new JObject();
    
                try
                {
                    jarrZipCodes = JArray.Parse(JsonConvert.SerializeObject(strZipCodes.Split(',')));
                    return jarrZipCodes.ToString();
                }
                catch (Exception ex)
                {
                    response["success"] = false;
                    response["error"] = "Failed to serialize zip code array, please check and try again";
                    response["exception"] = ex.ToString();
    
                    return response.ToString();
                }
            }
