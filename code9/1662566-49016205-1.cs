        public static string signalFCM(string msg, string user_firebase_id) //This must be gathered by storing a firebase_id created by an android device.
        {
            try
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = user_firebase_id,
                    notification = new	// *** THIS IS HOW FIREBASE SENDS THEM BY DEFAULT
                    {
                        body = msg,
                        title = "MyAPP",
                        sound = "Enabled"
                    },
                    // **** THIS IS THE CUSTOM EXTRA TO RETRIEVE ITS CONTENT ****
                    data = new
                    {
                        body = msg,
                        title = "MyAPP",
                        payload = "1"
                    }
                    // ******************
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", APP_KEY));	//This must be gathered from the Firebase Console APP page
                tRequest.Headers.Add(string.Format("Sender: id={0}", APP_ID)); //This must be gathered from the Firebase Console APP page
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                return sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)    {   return ex.Message;    }
        }
    }
