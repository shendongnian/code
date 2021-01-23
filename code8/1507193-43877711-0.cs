        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="ebayFullOrderId"></param>
        /// <param name="reason">Must be BUYER_ASKED_CANCEL or ADDRESS_ISSUES</param>
        private static bool Cancellation_SubmitCancelRequest(string authToken, string ebayFullOrderId, string reason)
        {
            var status = false;
            const string url = "https://api.ebay.com/post-order/v2/cancellation";
            var cancelOrderRequest = (HttpWebRequest)WebRequest.Create(url);
            cancelOrderRequest.Headers.Add("Authorization", "TOKEN " + authToken);
            cancelOrderRequest.ContentType = "application/json";
            cancelOrderRequest.Accept = "application/json";
            cancelOrderRequest.Headers.Add("X-EBAY-C-MARKETPLACE-ID", "EBAY_US");
            cancelOrderRequest.Method = "POST";
            //cancelOrderRequest.Headers.Add("legacyOrderId", ebayFullOrderId);
            using (var streamWriter = new StreamWriter(cancelOrderRequest.GetRequestStream()))
            {
                string json = "{\"legacyOrderId\":\"" + ebayFullOrderId + "\",\"cancelReason\":\"" + reason + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var response = (HttpWebResponse)cancelOrderRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            var reader = new JsonTextReader(new StringReader(result));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    var pt = reader.Path;
                    var val = reader.Value.ToString();
                    var isNumeric = !string.IsNullOrEmpty(val) && val.All(Char.IsDigit);
                    if (pt == "cancelId" & isNumeric == true)
                    {
                        status = true;
                        break;
                    }
                }
            }
            return status;
        }    
