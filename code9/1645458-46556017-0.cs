            try
            {
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream()))
                {
                    streamOut.Write(yourMessage);
                }
                using (StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    Console.WriteLine(streamIn.ReadToEnd());
                }
            }
            catch (SystemException se)
            {
                Console.WriteLine(se.Message);
            }
